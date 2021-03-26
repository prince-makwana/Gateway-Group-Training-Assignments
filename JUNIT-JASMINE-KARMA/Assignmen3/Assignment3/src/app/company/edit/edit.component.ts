import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Company } from 'src/app/models/company.model';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {

  companyId!: number;
  companyForm!: FormGroup;
  companyBranch!: FormArray;
  company!: Company;

  constructor(private route: ActivatedRoute, private formBuilder: FormBuilder, private service: SharedService, private router: Router) {
    
   }

  ngOnInit(): void {  
    
    this.companyId = parseInt(this.route.snapshot.params.id);

    this.companyForm = this.formBuilder.group({
      id: [],
      email: ['', Validators.required],
      name: ['', Validators.required],
      totalEmployee: [],
      address: ['', Validators.required],
      isCompanyActive: ['', Validators.required],
      totalBranch: [],
      companyBranch: this.formBuilder.array([])
    });

    this.service.getCompanyById(this.companyId).subscribe(data => {
      for(const index in data.companyBranch){
        this.addBranch();
      }
      this.companyForm.setValue(data); 
    });
  }

  createBranch(): FormGroup{
    return this.formBuilder.group({
      branchId: '',
      branchName: '',
      branchAddress: ''
    });
  }

  addBranch(): void {
    this.companyBranch = this.companyForm.get('companyBranch') as FormArray;
    this.companyBranch.push(this.createBranch());
  }

  getBranchArray() {
    return (this.companyForm.get('companyBranch') as FormArray).controls;
  }
  get formValidation(){
    return this.companyForm.controls;
  }

  removeBranch(index:number){
    this.companyBranch.removeAt(index);
  }

  editCompany() {
    this.company = this.companyForm.value;
    this.company.totalBranch = this.company.companyBranch.length;

    this.service.editCompany(this.company).subscribe(data => {
      this.router.navigate(['/list-company']);
   });
  }
}

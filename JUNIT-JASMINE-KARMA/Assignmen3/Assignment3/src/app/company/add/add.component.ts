import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Company } from 'src/app/models/company.model';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {

  companyForm! : FormGroup;
  companyBranch!: FormArray;
  company!: Company;

  constructor(private service: SharedService, private router: Router, private formBuilder: FormBuilder, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.companyForm = this.formBuilder.group({
      id: [],
      email: new FormControl('', [Validators.required, Validators.email]),
      name: new FormControl('', Validators.required),
      totalEmployee: new FormControl('', Validators.required),
      address: new FormControl('', Validators.required),
      isCompanyActive: new FormControl(''),
      totalBranch: new FormControl('', Validators.required),
      companyBranch: this.formBuilder.array([ ])
    });
  }

  createBranch(): FormGroup {
    return this.formBuilder.group({
      branchId: new FormControl('',[Validators.required]),
      branchName: new FormControl('',[Validators.required]),
      branchAddress: new FormControl('',[Validators.required])
    });
  }

  addBranch(): void {
    this.companyBranch = this.companyForm.get('companyBranch') as FormArray;
    this.companyBranch.push(this.createBranch());
  }

  getBranchArray() {
    return (this.companyForm.get('companyBranch') as FormArray).controls;
  }

  removeBranch(index: number) {
    this.companyBranch.removeAt(index);
  }

  get formValidation(){
    return this.companyForm.controls;
  }


  onSubmit() {
    this.company = this.companyForm.value;
    this.company.totalBranch = this.company.companyBranch.length;

    this.service.addCompany(this.company)
      .subscribe(data => {
        this.router.navigate(['list-company']);
      });
  }

}

import { Component, OnInit } from '@angular/core';
import { Company } from 'src/app/models/company.model';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {

  companies: Company[] = [];

  constructor(private service : SharedService) { }

  ngOnInit(): void {
    this.loadCompanyList();
  }

  loadCompanyList(){
    return this.service.getCompanyList().subscribe((data : Company[]) => {
      this.companies = data;
    });
  }

  delete(id: Number){
    this.service.deleteCompany(id).subscribe(() => {
      this.loadCompanyList();
    });
  }
}

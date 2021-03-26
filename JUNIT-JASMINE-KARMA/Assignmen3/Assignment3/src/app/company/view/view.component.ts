import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Company } from 'src/app/models/company.model';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-view',
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.css']
})
export class ViewComponent implements OnInit {

  companyId !: number;
  company : any;

  constructor(private route: ActivatedRoute, private service : SharedService) {
    this.company = Company;
  }

  ngOnInit(): void {
    this.companyId = parseInt(this.route.snapshot.params.id);
    this.service.getCompanyById(this.companyId).subscribe(data => {
      this.company = data;
    });
  }

}

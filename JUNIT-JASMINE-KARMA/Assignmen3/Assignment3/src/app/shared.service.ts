import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { Company } from './models/company.model';

@Injectable({
  providedIn: 'root'
})

export class SharedService {

  constructor(private _http : HttpClient) { }

  getCompanyList():Observable<Company[]>{
    return this._http.get<Company[]>("http://localhost:3000/companyInfo");
  }

  addCompany(company: any){
    return this._http.post("http://localhost:3000/companyInfo", company);
  }

  deleteCompany(id: Number){
    return this._http.delete("http://localhost:3000/companyInfo/" + id);
  }

  editCompany(company: Company){
    return this._http.put("http://localhost:3000/companyInfo/" + company.id, company);
  }

  getCompanyById(id: any){
    return this._http.get<Company>("http://localhost:3000/companyInfo/" + id);
  }
}

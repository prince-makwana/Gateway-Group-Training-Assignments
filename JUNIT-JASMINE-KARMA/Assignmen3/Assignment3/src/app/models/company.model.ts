import {Branch} from "./branch.model";

export class Company{
    id : number;
    name : string;
    email : string;
    totalEmployee : number;
    address : string;
    isCompanyActive : boolean;
    totalBranch : number;
    companyBranch: Branch[];

    constructor(id: number, name: string, email: string, totalEmployee: number, address: string, isCompanyActive: boolean, totalBranch: number){
        this.id = id;
        this.name = name;
        this.email = email;
        this.address = address;
        this.totalEmployee = totalEmployee;
        this.isCompanyActive = isCompanyActive;
        this.totalBranch = totalBranch;
        this.companyBranch = [];
    }
}
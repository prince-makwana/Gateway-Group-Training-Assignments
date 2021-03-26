export class Branch{
    branchId: number;
    branchName: string;
    branchAddress:string;

    constructor(branchId: number, branchName: string, branchAddress:string){
        this.branchId = branchId;
        this.branchName = branchName;
        this.branchAddress = branchAddress;
    }
}
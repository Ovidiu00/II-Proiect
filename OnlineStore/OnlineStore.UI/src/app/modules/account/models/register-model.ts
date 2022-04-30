export class RegisterModel{
  email:string;
  password:string;
  nume:string;
  prenume:String

  constructor(email:string,password:string,nume:string,prenume:string){
    this.email = email;
    this.password = password;
    this.nume = nume;
    this.prenume = prenume;
  }
}

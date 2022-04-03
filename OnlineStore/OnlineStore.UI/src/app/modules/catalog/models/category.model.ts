export class Category{

  public id :number;
  public name:string;
  public filePath?:string;
  public subCategories?: Category[];
}

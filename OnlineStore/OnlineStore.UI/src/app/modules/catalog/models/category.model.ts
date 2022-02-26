export class Category{

  public id :number;
  public name:string;
  public photo?:string;
  public description?:string;

  public subCategories?: Category[];
}

using System.Collections.Generic;

namespace OnlineStore.DataAccess.Models.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string FilePath { get; set; }
        public string Name { get; set; }
        public IEnumerable<Category> SubCategories { get; set; }
        public IList<Product> Products { get; set; }

        public Category()
        {
            this.SubCategories = new List<Category>();
            this.Products = new List<Product>();
        }
    }
}

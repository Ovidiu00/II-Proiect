using System;
using System.Collections.Generic;

namespace OnlineStore.DataAccess.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string FilePath { get; set; }
        public DateTime InsertedDate { get; set; }

        public Product()
        {
            this.Categories = new List<Category>();
        }
    }
}

using System;

namespace OnlineStore.Business.DTOs
{
   public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string FilePath { get; set; }

        public DateTime InsertedDate { get; set; }
    }
}

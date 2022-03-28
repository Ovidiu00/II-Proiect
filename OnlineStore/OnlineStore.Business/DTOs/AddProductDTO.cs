using Microsoft.AspNetCore.Http;
using System;

namespace OnlineStore.Business.DTOs
{
    public class AddProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string FilePath { get; set; }
        public DateTime InsertedDate { get; set; }
        public IFormFile Photo { get; set; }
    }
}

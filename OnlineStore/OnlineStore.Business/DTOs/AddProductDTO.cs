using Microsoft.AspNetCore.Http;

namespace OnlineStore.Business.DTOs
{
    public class AddProductDTO
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public IFormFile Photo { get; set; }
    }
}

using Microsoft.AspNetCore.Http;

namespace OnlineStore.API.ViewModels
{
    public class AddProductVM
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public IFormFile Photo { get; set; }
    }
}

using Microsoft.AspNetCore.Http;

namespace OnlineStore.API.ViewModels
{
    public class AddProductVM
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public string Quantity { get; set; }
        public IFormFile Photo { get; set; }
    }
}

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.API.ViewModels
{
    public class AddProductVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Price { get; set; }
        [Required]
        public string Quantity { get; set; }
        [Required]
        public IFormFile Photo { get; set; }
    }
}

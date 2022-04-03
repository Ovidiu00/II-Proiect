using System;
using Microsoft.AspNetCore.Http;

namespace OnlineStore.Business.DTOs
{
    public class AddCategoryDTO
    {
        public string Name { get; set; }
        public IFormFile Photo { get; set; }
    }
}
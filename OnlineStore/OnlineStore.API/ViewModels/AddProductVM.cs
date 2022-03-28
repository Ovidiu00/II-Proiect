﻿using Microsoft.AspNetCore.Http;

namespace OnlineStore.API.ViewModels
{
    public class AddProductVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string FilePath { get; set; }
        public IFormFile Photo { get; set; }
    }
}

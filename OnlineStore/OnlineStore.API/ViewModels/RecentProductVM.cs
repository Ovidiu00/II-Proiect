using System;

namespace OnlineStore.API.ViewModels
{
    public class RecentProductVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
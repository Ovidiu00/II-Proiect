using System;

namespace OnlineStore.API.ViewModels
{
    public class PopularProductVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string FilePath { get; set; }

        public DateTime InsertedDate { get; set; }
    }
}

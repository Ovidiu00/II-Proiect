using System;
using System.Collections.Generic;

namespace OnlineStore.DataAccess.Models.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public DateTime DateOfOrder { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}

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
        public ICollection<OrderProduct> Products { get; set; }

        public Order()
        {
            Products = new List<OrderProduct>();
        }
    }
}

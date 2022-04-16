namespace OnlineStore.DataAccess.Models.Entities
{
    public class UserProduct
    {
        public string UserId { get; set; }
        public User User { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }


        public int Quantity { get; set; }
    }
}

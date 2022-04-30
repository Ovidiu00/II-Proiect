namespace OnlineStore.Business.DTOs
{
    public class UserDTO
    {
        public string UserId { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Email { get; set; }
        public bool isAdmin { get; set; }
    }
}

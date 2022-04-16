namespace OnlineStore.Business.DTOs
{
    public class LoginResponseDTO
    {
        public LoginResponseDTO(string token, UserDTO user)
        {
            Token = token;
            User = user;
        }

        public string Token { get; set; }
        public UserDTO User { get; set; }
    }
}

using OnlineStore.Business.DTOs;

namespace OnlineStore.API.ViewModels
{
    public class LoginResponseVM
    {
        public LoginResponseVM(string token, UserDTO user)
        {
            Token = token;
            User = user;
        }

        public string Token { get; set; }
        public UserDTO User { get; set; }
    }
}

using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineStore.DataAccess.Models.Entities
{
    public class User : IdentityUser
    {
        public string Nume { get; set; }
        public string Prenume { get; set; }
        
        public ICollection<UserProduct> Products { get; set; }
        public User(string nume, string prenume,string email)
        {
            Nume = nume;
            Prenume = prenume;
            base.Email = email;
            base.UserName = email;
            
        }

        public User()
        {
            Products = new List<UserProduct>();
        }
    }
}

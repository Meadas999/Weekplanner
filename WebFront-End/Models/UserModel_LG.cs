using System.ComponentModel.DataAnnotations;

namespace WebFront_End.Models
{
    public class UserModel_LG
    {
        [Required]
        public string? Email { get; set; } 
        [Required]
        public string? Password { get; set; } 
        public bool Retry { get; set; }

        public UserModel_LG(string email, string password)
        {
            Email = email;
            Password = password;
        }
        public UserModel_LG()
        {
        }
    }
}

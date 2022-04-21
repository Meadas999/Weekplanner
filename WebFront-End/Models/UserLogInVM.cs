using System.ComponentModel.DataAnnotations;

namespace WebFront_End.Models
{
    public class UserLogInVM
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; } 
        [Required]
        public string? Password { get; set; } 
        public bool Retry { get; set; }

        public UserLogInVM(string email, string password)
        {
            Email = email;
            Password = password;
        }
        public UserLogInVM()
        {
        }
    }
}

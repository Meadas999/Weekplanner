using System.ComponentModel.DataAnnotations;

namespace WebFront_End.Models
{
    public class UserLogInVM
    {
        
        [EmailAddress]
        [Required(ErrorMessage = "Voer u e-mailadres in.")]
        public string? Email { get; set; } 
        [Required(ErrorMessage = "Voer u wachtwoord in.")]
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

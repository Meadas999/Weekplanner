using System.ComponentModel.DataAnnotations;
using WeekplannerClassesLibrary;

namespace WebFront_End.Models
{
    public class RegisterVM
    {
        [StringLength(50, MinimumLength = 1, ErrorMessage = "First name can only contain 50 characters.")]
        [Required(ErrorMessage = "First name can not be empty.")]
        public string? FirstName { get; set; }
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Last name can only contain 50 characters.")]
        [Required(ErrorMessage = "Last name can not be empty.")]
        public string? LastName { get; set; }
        [StringLength(50, MinimumLength = 10, ErrorMessage = "Password must contain atleast 10 characters.")]
        [Required(ErrorMessage = "Password of atleast 10 characters is required.")]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Birth date is required.")]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "Weight is required.")]
        public double Weight { get; set; }
        [Required(ErrorMessage = "Length is required.")]
        public int Length { get; set; }

        public RegisterVM()
        {

        }

        public RegisterVM(string firstName, string lastName, string password, string email,
                          DateTime birthDate, double weight, int length)
        {
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            Email = email;
            BirthDate = birthDate;
            Weight = weight;
            Length = length;
        }

        public User ToUser()
        {
            return new User(FirstName, LastName, Email, BirthDate, Weight, Length);
        }
    }
}

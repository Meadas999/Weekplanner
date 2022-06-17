using System.ComponentModel.DataAnnotations;
using WeekplannerClassesLibrary;

namespace WebFront_End.Models
{
    public class RegisterVM
    {
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public double Weight { get; set; }
        [Required]
        public int Length { get; set; }

        public RegisterVM()
        {

        }

        public RegisterVM(string? firstName, string? lastName, string? password, string? email,
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

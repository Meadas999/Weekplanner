namespace WeekplannerClassesLibrary
{
    public abstract class UserBase
    {
        public int UserId { get;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }

        public UserBase(int userid, string firstname, string lastname, string email, DateTime birthdate)
        {
            this.UserId = userid;
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Email = email;
            this.BirthDate = birthdate;
        }

        public UserBase(string firstName, string lastName, string email, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            BirthDate = birthDate;
        }

        public UserBase(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
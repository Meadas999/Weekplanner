namespace WeekplannerClassesLibrary
{
    public abstract class UserBase
    {
        protected string FirstName { get; }
        protected string LastName { get; }
        protected string Email { get; }
        protected DateTime BirthDate { get; set; }
        protected string Password { get;}
        
        public UserBase(string firstname,string lastname, string email, string password, DateTime birthdate)
        {
            
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Email = email;
            this.Password = password;
            this.BirthDate = birthdate;

        }

        public string GetEmail()
        {
            return Email;
        }

        public string GetFullName()
        {
            return $"{this.FirstName}  {this.LastName}";
        }

        public string GetFirstName()
        { 
            return FirstName;
        }

        public string GetLastName()
        { 
            return LastName;
        }

        public string GetPassword()
        { 
            return Password;
        }

        public DateTime GetBirthDate()
        {
            return BirthDate.Date;
        }
    }
}
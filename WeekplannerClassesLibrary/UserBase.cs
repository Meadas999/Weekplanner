namespace WeekplannerClassesLibrary
{
    public abstract class UserBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Password { get; set; }
        //FIXME: Password should be encrypted.
        
        public UserBase(string firstname,string lastname, string email, string password, DateTime birthdate)
        {
            
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Email = email;
            this.Password = password;
            this.BirthDate = birthdate;

        }

       
    }
}
namespace WeekplannerClassesLibrary
{
    public abstract class UserBase
    {
        public int UserId { get;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Instantieert een baseclasse van de user
        /// </summary>
        /// <param name="userid">Id van de gebruiker.</param>
        /// <param name="firstname">Voornaam van de gebruiker.</param>
        /// <param name="lastname">Achternaam van de gebruiker.</param>
        /// <param name="email">Email van de gebruiker.</param>
        /// <param name="birthdate">Geboortedatum van de gebruiker.</param>
        public UserBase(int userid, string firstname, string lastname, string email, DateTime birthdate)
        {
            this.UserId = userid;
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Email = email;
            this.BirthDate = birthdate;
        }
        /// <summary>
        /// Instantieert een baseclasse van de user
        /// </summary>
        /// <param name="firstName">Voornaam van de gebruiker.</param>
        /// <param name="lastName">Achternaam van de gebruiker.</param>
        /// <param name="email">Email van de gebruiker.</param>
        /// <param name="birthDate">Geboortedatum van de gebruiker.</param>
        public UserBase(string firstName, string lastName, string email, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            BirthDate = birthDate;
        }
        /// <summary>
        /// Instantieert een baseclasse van de user
        /// </summary>
        /// <param name="firstName">Voornaam van de gebruiker.</param>
        /// <param name="lastName">Achternaam van de gebruiker.</param>
        public UserBase(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
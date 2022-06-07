using WeekplannerClassesLibrary;

namespace WebFront_End.Models
{
    public class UserVoedingVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<VoedingVM> Voedingen { get; set; }

        public UserVoedingVM()
        {

        }

        public UserVoedingVM(int id, string firstName, string lastName, List<VoedingVM> voedingen)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Voedingen = voedingen;
        }

        public UserVoedingVM(User user, List<Voeding> voedingen)
        {
            Id = user.UserId;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Voedingen = voedingen.Select(x => new VoedingVM(x)).ToList();
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}

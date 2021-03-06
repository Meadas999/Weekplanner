using InterfaceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekplannerClassesLibrary
{
    public class ActiviteitContainer
    {
        private readonly IActiviteitenContainer container;

        public ActiviteitContainer(IActiviteitenContainer container)
        {
            this.container = container;
        }
        //Zet de parameters om in de juist instantie en voert de methode uit.
        public void AddActivityToUserWTTime(int id, Activiteit activiteit)
        {
            container.AddActivityToUserWithDayOnly(id, activiteit.ToDTO());
        }

        //public int GetAmountActivitysDay(User user, DateTime date)
        //{
        //    return container.GetAmountActivitysDay(user.ToDTO(), date);
        //}
        
        //Zet de parameters om in de juist instantie en voert de methode uit.
        public List<Activiteit> GetAllEvents(int id)
        {
            return container.GetAllEvents(id).Select(x => new Activiteit(x)).ToList();
        }

        //public List<Activiteit> GetEventsInfoDay(User user, DateTime day)
        //{ 
        //    return container.GetEventsInfoDay(user.ToDTO(), day).Select(a => new Activiteit(a)).ToList();
        //}

        //Zet de parameters om in de juist instantie en voert de methode uit.
        public void UpdateActivityWithDayOnly(Activiteit activiteit, int id)
        {
            container.UpdateActivityWithDayOnly(activiteit.ToDTO(), id);
        }

        //Zet de parameters om in de juist instantie en voert de methode uit.
        public Activiteit GetActivityById(int id)
        {
            if (container.GetActivityById(id) != null)
            {
                Activiteit activiteit = new(container.GetActivityById(id));
                return activiteit;
            }
            else 
            {
                return null;
            }
        }
        //Verwijdert de activiteit op basis van een activiteitsid..
        public void DeleteActivityById(int id)
        {
            container.DeleteActivityById(id);
        }


    }
}

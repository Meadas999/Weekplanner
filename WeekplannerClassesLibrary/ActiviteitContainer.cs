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

        public void AddActivityToUserWTTime(User user, Activiteit activiteit)
        {
            container.AddActivityToUserWithDayOnly(user.ToDTO(), activiteit.ToDTO());
        }

        public int GetAmountActivitysDay(User user, DateTime date)
        {
            return container.GetAmountActivitysDay(user.ToDTO(), date);
        }

        public List<Activiteit> GetAllEvents(int id)
        {
            return container.GetAllEvents(id).Select(x => new Activiteit(x)).ToList();
        }
        

        public List<Activiteit> GetEventsInfoDay(User user, DateTime day)
        { 
            return container.GetEventsInfoDay(user.ToDTO(), day).Select(a => new Activiteit(a)).ToList();
        }

        public void UpdateActivityWithDayOnly(Activiteit activiteit, int id)
        {
            container.UpdateActivityWithDayOnly(activiteit.ToDTO(), id);
        }

        public Activiteit GetActivityById(int id)
        {
            Activiteit activiteit = new(container.GetActivityById(id));
            return activiteit;
        }



    }
}

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
            container.AddActivityToUserWTTime(user.ToDTO(), activiteit.ToDTO());
        }

        public int GetAmountActivitysDay(User user, DateTime date)
        {
            return container.GetAmountActivitysDay(user.ToDTO(), date);
        }

        public List<Activiteit> GetEventsInfoDay(User user, DateTime day)
        {
            List<ActiviteitDTO> activiteiten = container.GetEventsInfoDay(user.ToDTO(), day);
            List<Activiteit> activiteitenLijst = new List<Activiteit>();
            foreach (ActiviteitDTO activiteit in activiteiten)
            {
                activiteitenLijst.Add(new Activiteit(activiteit));
            }
            return activiteitenLijst;
        }


        
    }
}

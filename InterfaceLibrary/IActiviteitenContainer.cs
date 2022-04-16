using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLibrary
{
    public interface IActiviteitenContainer
    {
        public void AddActivityToUserWithDayOnly(int id, ActiviteitDTO activiteit);
        public int GetAmountActivitysDay(UserDTO user, DateTime date);
        public List<ActiviteitDTO> GetEventsInfoDay(UserDTO user, DateTime day);
        public List<ActiviteitDTO> GetAllEvents(int id);
        public void UpdateActivityWithDayOnly(ActiviteitDTO activiteit, int id);
        public ActiviteitDTO GetActivityById(int id);
        public void DeleteActivityById(int id);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLibrary
{
    public interface IActiviteitenContainer
    {
        public void AddActivityToUserWTTime(UserDTO user, ActiviteitDTO activiteit);
        public int GetAmountActivitysDay(UserDTO user, DateTime date);
        public List<ActiviteitDTO> GetEventsInfoDay(UserDTO user, DateTime day);


    }
}

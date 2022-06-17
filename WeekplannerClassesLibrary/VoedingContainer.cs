using InterfaceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekplannerClassesLibrary
{
    public class VoedingContainer
    {
        private readonly IVoedingContainer container;

        public VoedingContainer(IVoedingContainer container)
        {
            this.container = container;
        }

        public void AddVoeding(Voeding voeding, int userid)
        {
            container.AddVoeding(voeding.ToDTO(), userid);
        }

        public List<Voeding> GetAllvoedingenFrUser(int userid)
        {
            return container.GetAllVoedingFrUser(userid).Select(v => new Voeding(v)).ToList();
        }

        public void UpdateVoeding(Voeding voeding)
        {
            container.UpdateVoeding(voeding.ToDTO());
        }

        public void DeleteVoeding(int id)
        {
            container.DeleteVoeding(id);
        }
    }
}

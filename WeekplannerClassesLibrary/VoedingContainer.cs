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
        private readonly IVoedingContainer Container;

        public VoedingContainer(IVoedingContainer container)
        {
            Container = container;
        }
        public void AddVoeding(Voeding voeding, int userid)
        {
            Container.AddVoeding(voeding.ToDTO(), userid);
        }
        public List<Voeding> GetAllVoedingFrUser(int userid)
        {
            return Container.GetAllVoedingFrUser(userid).Select(x => new Voeding(x)).ToList();
        }
        public void UpdateVoeding(Voeding v)
        {
            Container.UpdateVoeding(v.ToDTO());
        }
        public void DeleteVoeding(int id)
        {
            Container.DeleteVoeding(id);
        }

        public Voeding GetById(int id)
        {
            return new Voeding(Container.GetById(id));
        }
    }
}

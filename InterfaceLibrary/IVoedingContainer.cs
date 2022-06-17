using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLibrary
{
    public interface IVoedingContainer
    {
        public void AddVoeding(VoedingDTO voeding, int userid);
        public List<VoedingDTO> GetAllVoedingFrUser(int userid);
        public void UpdateVoeding(VoedingDTO dto);
        public void DeleteVoeding(int id);
    }
}

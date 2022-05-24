using InterfaceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALmssqlServer
{
    public class VoedingMSSQLDAL : IVoedingContainer
    {
       Database db = new();

        public void AddVoeding(VoedingDTO voeding)
        {
            try
            {
                db.MakeConnection();
                string query = ""

            }
            catch ()
            { 
            
            }
        }




    }
}

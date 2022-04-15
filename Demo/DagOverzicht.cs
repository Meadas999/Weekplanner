using DALmssqlServer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WeekplannerClassesLibrary
{
    public partial class DagOverzicht : Form
    {
        DateTime Date;
        User TUser;
        ActiviteitContainer AC = new (new ActiviteitenMSSQLDAL());
        public DagOverzicht(DateTime date, User user)
        {
            InitializeComponent();
            this.Date = date;
            TUser = user;
            
        }

        private void activiteiten_LB_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void DagOverzicht_Load(object sender, EventArgs e)
        {
            if (AC.GetEventsInfoDay(TUser, Date).Count > 0)
            {
                activiteiten_LB.DataSource = AC.GetEventsInfoDay(TUser, Date);
            }
            
        }
    }
}

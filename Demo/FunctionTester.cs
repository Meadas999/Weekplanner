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
using WeekplannerClassesLibrary;

namespace Demo
{
    public partial class FunctionTester : Form
    {
        private UserContainer UC = new(new UserMSSQLDAL());
        private ActiviteitContainer AC = new(new ActiviteitenMSSQLDAL());
        public FunctionTester()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FunctionTester_Load(object sender, EventArgs e)
        {
            User user = UC.FindUserById(4);
            user.activitys = AC.GetAllEvents(user.UserId);
            listBox1.DataSource = user.activitys;
        }
    }
}

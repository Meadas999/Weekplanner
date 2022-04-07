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
    public partial class Activity : Form
    {
        User user;
        Database db = new(); 
        ActiviteitContainer AC = new ActiviteitContainer(new ActiviteitenMSSQLDAL());
        public Activity(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        public Activity(DateTime dateTime, User user)
        {
            InitializeComponent();
            date_Picker.Value = dateTime;
            this.user = user;
            

        }

        private void Activity_Load(object sender, EventArgs e)
        {
            
        }

        

        private void TimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void add_Btn_Click(object sender, EventArgs e)
        {
            /*DateOnly datum = DateOnly.FromDateTime(date_Picker.Value);*/
            Activiteit activity = new(TypeCB.Text, titel_TB.Text, beschrijving_RTB.Text, date_Picker.Value);
            AC.AddActivityToUserWTTime(user, activity);
            user.activitys.Add(activity);
            this.Close();
        }
    }
}

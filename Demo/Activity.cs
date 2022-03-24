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
        DataBase DB = new DataBase();
        public Activity(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        public Activity(DateTime dateTime)
        {
            InitializeComponent();
            date_Picker.Value = dateTime;
            

        }

        private void Activity_Load(object sender, EventArgs e)
        {
            
        }

        

        private void TimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void add_Btn_Click(object sender, EventArgs e)
        {
            DateOnly datum = DateOnly.FromDateTime(date_Picker.Value);
            Activiteit activity = new(TypeCB.Text, titel_TB.Text, beschrijving_RTB.Text, datum);
            DB.AddActivityToUserWTTime(user, activity);
            user.activitys.Add(activity);
            this.Close();
        }
    }
}

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
        DataBase DB = new DataBase();
        public Activity()
        {
            InitializeComponent();
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
    }
}

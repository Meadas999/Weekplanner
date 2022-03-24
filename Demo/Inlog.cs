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
    public partial class Inlog : Form
    {
        DataBase DB = new();
        public Inlog()
        {
            InitializeComponent();
        }

        private void Inlog_Load(object sender, EventArgs e)
        {

        }

        private void register_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register register = new();
            register.ShowDialog();
            this.Close();
        }

        private void Inlogbtn_Click(object sender, EventArgs e)
        {
            if (DB.CheckInlogDataCorrect(username_TB.Text.ToLower(), password_Tb.Text))
            {
                Form1 MainMenu = new(DB.LogIn(username_TB.Text.ToLower()));
                this.Hide();
                MainMenu.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Username/Password is incorrect, please try again.");
            }
            
        }
    }
}

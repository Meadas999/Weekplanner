using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DALmssqlServer;

namespace WeekplannerClassesLibrary
{
    public partial class Inlog : Form
    {
        UserContainer UC = new(new UserMSSQLDAL());
        public Inlog()
        {
            InitializeComponent();
        }

        private void Inlog_Load(object sender, EventArgs e)
        {
            username_TB.Text = "jeans123@hotmail.com";
            password_Tb.Text = "Amier123";
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
            User user = UC.FindUserByEmailAndPassword(username_TB.Text.ToLower(), password_Tb.Text);
            if (user != null)
            {
                Form1 MainMenu = new(user);
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

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
    public partial class Register : Form
    {
        UserContainer UC = new(new UserMSSQLDAL());
        Inlog inlog = new();
        
        public Register()
        {
            InitializeComponent();
        }
        public void OpenInlogForm()
        {
            this.Hide();
            inlog.ShowDialog();
            this.Close();
            
        }
        private void register_Btn_Click(object sender, EventArgs e)
        {
            if (!UC.CheckForUsedEmail(email_Tb.Text))
            {
                User user = new(firstname_Tb.Text, lastname_Tb.Text, email_Tb.Text.ToLower(), password_Tb.Text, Birthdate_Tpicker.Value, Convert.ToDouble(weight_Tb.Text), Convert.ToInt16(lenght_Tb.Text));
                UC.AddUser(user.ToDTO());
                OpenInlogForm();
            }
            else 
            {
                MessageBox.Show($"De gebruikte E-mail is al in gebruik");
            }

        }
    }
}

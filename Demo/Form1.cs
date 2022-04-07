using System;
using System.Globalization;
using System.Reflection;
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
    public partial class Form1 : Form
    {
       
        DateTime now = DateTime.Now;
        User User;
        UserContainer UC = new UserContainer(new UserMSSQLDAL());

        int Month;
        int Year;
        
        public Form1(User user)
        {
            InitializeComponent();
            this.User = user;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Month = now.Month;
            Year = now.Year;
            ShowDays(Year, Month);
        }
        private void ShowDays(int year, int month)
        {
            DayContainer.Controls.Clear();
            DateTime startofthemonth = new DateTime(year , month, 1);
            int days = DateTime.DaysInMonth(year, month);
            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d"))+1;
            MakeBoxes(dayoftheweek);
            MakeDayBoxes(days);
           
            YearMonthLBL.Text = $"{DateTimeFormatInfo.CurrentInfo.GetMonthName(Month)}  {Year}";
        }

        private void MakeBoxes(int dayoftheweek)
        {
            for (int i = 1; i < dayoftheweek; i++)
            {
                VakjesUserControl Boxes = new VakjesUserControl();
                DayContainer.Controls.Add(Boxes);
            }
        }

        private void MakeDayBoxes(int days)
        {
            for (int i = 1; i <= days; i++)
            {
                DayBoxUserControl DaysBox = new DayBoxUserControl(this.User,Month,Year);
                DaysBox.days(i);
                DaysBox.Tag = i;
                DaysBox.ShowEvents();
                DayContainer.Controls.Add(DaysBox);
            }
        }
        private void NextBtn_Click(object sender, EventArgs e)
        {
            if (Month != 12)
            {
                Month++;
                ShowDays(Year, Month);
            }
            else { ShowDays(Year++, Month = 1); }
            
        }

        private void PreviousBtn_Click(object sender, EventArgs e)
        {
            if (Month != 12)
            {
                Month--;
                ShowDays(Year, Month);
            }
            else { ShowDays(Year--, Month = 1); }
        }

        private void register_btn_Click(object sender, EventArgs e)
        {
           
            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
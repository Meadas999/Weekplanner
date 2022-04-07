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
    public partial class DayBoxUserControl : UserControl
    {
        string Month;
        string Year;
        string date;
        ActiviteitContainer AC = new(new ActiviteitenMSSQLDAL());
        User user;
        public DayBoxUserControl(User user,int month, int year)
        {
            InitializeComponent();
            if (month < 10)
            { 
                Month = 0.ToString()+month.ToString();
                Year = year.ToString();
            }
            else if (month >=10)
            {
                Month = month.ToString();
                Year = year.ToString();
            }
            this.user = user;
            
           
        }

        public DayBoxUserControl(int month, int year)
        {
            InitializeComponent();
            if (month < 10)
            {
                Month = 0.ToString() + month.ToString();
                Year = year.ToString();
            }
            else if (month >= 10)
            {
                Month = month.ToString();
                Year = year.ToString();
            }
    
        }

        public void ShowEvents()
        {
            string dateofbox = $"{Year}/{Month}/{GiveDay()}";
            if (AC.GetAmountActivitysDay(user, MakeDate(dateofbox)) > 0)
            {
                events_Lbl.Text = $"{AC.GetAmountActivitysDay(user, MakeDate(dateofbox))}  event(s)";
            }
            else
            {
                events_Lbl.Text = "";
            }
        }

        private void DayBoxUserControl_Load(object sender, EventArgs e)
        {

        }
        public DateTime MakeDate(string Givendate)
        { 
            DateTime date = Convert.ToDateTime(Givendate);
            return date.Date;
        }
        public string GiveDay()
        {
            if (Convert.ToInt32(this.Tag) < 10)
            { return 0.ToString() + this.Tag.ToString(); }
            else
            {  return this.Tag.ToString(); }
            

        }
        
        public void days(int numday)
        {
            DaysLbl.Text = numday + "";
        }

        private void DayBoxUserControl_DoubleClick(object sender, EventArgs e)
        {
            date = $"{Year}/{Month}/{GiveDay()}";
            Activity activity = new(MakeDate(date), user);
            activity.ShowDialog();
        }

        private void events_Lbl_Click(object sender, EventArgs e)
        {
            date = $"{Year}/{Month}/{GiveDay()}";
            DagOverzicht dagOverzicht = new(MakeDate(date), user);
            dagOverzicht.ShowDialog();  
        }
    }
}

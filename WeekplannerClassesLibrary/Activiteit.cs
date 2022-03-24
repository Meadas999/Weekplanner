using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekplannerClassesLibrary
{
    public class Activiteit
    {
        private string Type;
        private string Name;
        private string Description;
        private DateTime Reminder;
        private DateTime Time;
        private Color Color;

        public Activiteit(string type, string name, string description, DateTime reminder, DateTime time, Color color)
        {
            this.Type = type;
            this.Name = name;
            this.Description = description;
            this.Reminder = reminder;
            this.Time = time;
            this.Color = color;
        }

        public void ChangeActivityName(string name)
        {
            this.Name = name;
            // TODO: Database veranderen
        }
        public void ChangeActivityType(string type)
        {
            this.Type = type;
            // TODO: Database veranderen
        }
        public void ChangeActivityDescription(string description)
        {
            this.Description = description;
            // TODO: Database veranderen
        }
        public void ChangeActivityReminder(DateTime reminder)
        {
            this.Reminder = reminder;
            // TODO: Database veranderen
        }
        public void ChangeActivityTime(DateTime time)
        {
            this.Time = time;
            // TODO: Database veranderen
        }
        public void ChangeActivityColor(Color color)
        {
            this.Color = color;
            // TODO: Database veranderen
        }


    }
}

﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekplannerClassesLibrary
{
    public class Activiteit
    {
        public int Id;
        public string Type;
        public string Name;
        public string Description;
        public DateTime Reminder;
        public DateTime DateTime;
        public Color Color;

        public Activiteit(int id, string type, string name, string description, DateTime reminder, DateTime datetime)
        {
            this.Id = id;
            this.Type = type;
            this.Name = name;
            this.Description = description;
            this.Reminder = reminder;
            this.DateTime = datetime;
        }

        public Activiteit(int id,string type, string name, string description, DateTime datetime)
        {
            this.Id = id;
            this.Type = type;
            this.Name = name;
            this.Description = description;
            this.DateTime = datetime;
        }

        public Activiteit(string type, string name, string description, DateTime datetime)
        {
         
            this.Type = type;
            this.Name = name;
            this.Description = description;
            this.DateTime = datetime;
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
            this.DateTime = time;
            // TODO: Database veranderen
        }
        public void ChangeActivityColor(Color color)
        {
            this.Color = color;
            // TODO: Database veranderen
        }

        public override string ToString()
        {
            return $"{Type}/{Name}/{Description}/{DateTime.ToString()}/";
        }

    }
}

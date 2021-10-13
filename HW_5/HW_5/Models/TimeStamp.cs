using System;
using System.Windows;

namespace HW_5.Models
{
    class TimeStamp
    {
        public TimeStamp(string hours, string minutes, string seconds)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }

        public TimeStamp() { }

        private string seconds;
        private string Seconds
        {
            get { return seconds; }
            set 
            {
                if (Int32.Parse(value) >= 60)
                    throw ex;
                seconds = normalize(value);
            }
        }

        private string minutes;
        private string Minutes
        {
            get { return minutes; }
            set 
            {
                if (Int32.Parse(value) >= 60)
                    throw ex; 
                minutes = normalize(value);
            }
        }

        private string hours;
        private string Hours
        {
            get { return hours; }
            set
            {
                if (Int32.Parse(value) >= 24)
                    throw ex;
                hours = normalize(value);
            }
        }

        public string TimeStampString
        {
            get { return Hours + ":" + Minutes + ":" + Seconds; }
            set
            {
                string[] time = value.Split(":");
                Hours = time[0];
                Minutes = time[1];
                Seconds = time[2];
            }
        }

        private string normalize(string value)
        {
            if (value.Length == 1)
                value = "0" + value;
            return value;
        }

        Exception ex = new Exception("Invalid input");

        public void timeChanger(int hoursModification, int minutesModification, int secondsModification)
        {
            int time = Int32.Parse(Hours) * 3600 + Int32.Parse(Minutes) * 60 + Int32.Parse(Seconds);
            int timeModification = hoursModification * 3600 + minutesModification * 60 + secondsModification;
            if (time + timeModification < 0)
                time = 86400 + time + timeModification;
            else
                time = (time + timeModification) % 86400;
            Hours = (time / 3600).ToString();
            Minutes = (time / 60 % 60).ToString();
            Seconds = (time % 60).ToString();
        }

        new public string ToString()
        {
            return "A timestamp of the type of (hours:minutes:seconds). Contains time " + TimeStampString;
        }
    }
}

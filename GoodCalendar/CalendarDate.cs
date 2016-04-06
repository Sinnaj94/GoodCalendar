using System;
using System.Collections.Generic;
using Microsoft.Phone.UserData;
using System.Windows;


namespace GoodCalendar
{
    class CalendarDate
    {
        List<Appointment> appointments;
        List<String> stringListe;
        Background a;
        int dayNumber;
        public CalendarDate(Background a, int dayNumber)
        {
            stringListe = new List<string>();
            appointments = new List<Appointment>();
            this.a = a;
            this.dayNumber = dayNumber;
        }


        public void init()
        {
            Appointments appts = new Appointments();

            //Identify the method that runs after the asynchronous search completes.
            appts.SearchCompleted += new EventHandler<AppointmentsSearchEventArgs>(buildListen);

            DateTime start = DateTime.Now;
            DateTime end = start.AddDays(dayNumber);
            int max = 100;

            //Start the asynchronous search.
            appts.SearchAsync(start, end, max, "Appointments Test #1");
        }

        public bool isSameDay(DateTime a, DateTime b)
        {
            if (a.Day == b.Day && a.Month == b.Month && a.Year == b.Year)
            {
                return true;
            }
            return false;
        }

        public List<String> buildString(DateTime d)
        {
            List<String> rueckgabe = new List<String>();
            foreach (Appointment a in appointments)
            {
                String temp = "";
                
                if (isSameDay(a.StartTime, d))
                {
                    if (a.Subject != null)
                    {
                        temp += a.Subject;
                        if (a.Location != null)
                        {
                            temp += " (";
                            temp += a.Location;
                            temp += ")";
                        }
                        rueckgabe.Add(temp);
                        stringListe.Add(temp);
                    }
                }
            }
            return rueckgabe;
        }

        public List<String> getString(DateTime tag)
        {
            return stringListe;
        }

        void buildListen(object sender, AppointmentsSearchEventArgs e)
        {
            //copy the list
            foreach(Appointment app in e.Results)
            {
                appointments.Add(app);
            }
            
            buildString(DateTime.Now);
            a.notify();         

        }
    }

}

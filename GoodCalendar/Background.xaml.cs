using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Globalization;

namespace GoodCalendar
{
    public partial class Background : PhoneApplicationPage
    {
        CalendarDate cDate;
        int maxDays;
        List<String> appended;
        int maxViewableDays;
        public Background()
        {
            maxViewableDays = 4;
            InitializeComponent();
            maxDays = 7;
            appended = new List<String>();
            cDate = new CalendarDate(this, maxDays);
            cDate.init();
        }

        

        public void buildScreen()
        {
            
            DateTime date = DateTime.Now;
            List<String> temp;
            for(int i = 0; i < maxDays; i++)
            {
                temp = cDate.buildString(date);
                if (temp.Any())
                {
                    switch (maxViewableDays)
                    {
                        case 4:
                            title1.Text = getDate(i);
                            myDates1.ItemsSource = temp;
                            title1.Visibility = Visibility.Visible;
                            break;
                        case 3:
                            title2.Text = getDate(i);
                            myDates2.ItemsSource = temp;
                            title2.Visibility = Visibility.Visible;
                            break;
                        case 2:
                            title3.Text = getDate(i);
                            myDates3.ItemsSource = temp;
                            title3.Visibility = Visibility.Visible;
                            break;
                        case 1:
                            title4.Text = getDate(i);
                            myDates4.ItemsSource = temp;
                            title4.Visibility = Visibility.Visible;
                            break;
                        default:
                            break;
                    }
                    maxViewableDays--;

                    
                }
                
                date = date.AddDays(1);
            }
  
        }

        public String getDate(int i)
        {
            DateTime datea = DateTime.Now;
            switch (i) {
                case 0:
                    return "today";
                    
                case 1:
                    return "tomorrow";

                default:
                    
                    datea = datea.AddDays(i);
                    String r = "";
                    if (datea.Day < 10)
                    {
                        r += "0";
                    }
                    r += datea.Day;
                    r += ".";
                    if(datea.Month < 10)
                    {
                        r += "0";
                    }
                    r += datea.Month;
                    
                    r += ". (";
                    r += datea.DayOfWeek;
                    r += ")";
                    return r;
            }
        }

        public String getDayOfWeek(DateTime a)
        {
            
            return "";
            
        }



        public void notify()
        {
            buildScreen();
        }

        
    }
}
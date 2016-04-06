using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace GoodCalendar
{
    public partial class Settings : PhoneApplicationPage
    {
        public double normalSizeHeader;
        public double normalSizeEvent;
        public Settings()
        {
            InitializeComponent();
            normalSizeHeader = Header.FontSize;
            normalSizeEvent = ExampleEvent.FontSize;
        }

        public void changeSize(double percent)
        {
            Header.FontSize = normalSizeHeader * percent;
            ExampleEvent.FontSize = normalSizeEvent * percent;
        }

        public void setToSmall(object sender, RoutedEventArgs e)
        {
            changeSize(.75);   
        }

        public void setToMedium(object sender, RoutedEventArgs e)
        {
            changeSize(1);
        }

        public void setToBig(object sender, RoutedEventArgs e)
        {
            changeSize(1.25);
        }

        public void setToHuge(object sender, RoutedEventArgs e)
        {
            changeSize(1.5);
        }

        private void Button_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Background.xaml", UriKind.Relative));
        }
    }
}
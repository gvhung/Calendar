using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Calendar
{
    public class MeetingHome : TabbedPage
    {
        public MeetingHome()
        {
            this.Children.Add(new MeetingList());
            this.Children.Add(new MeetingRequest());
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}

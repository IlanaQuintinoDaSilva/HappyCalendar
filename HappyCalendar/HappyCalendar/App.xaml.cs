using HappyCalendar.OffLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

using Xamarin.Forms;

namespace HappyCalendar
{
	public partial class App : Application
	{
        private const string TitleKey = "Name";

        public App ()
		{
			InitializeComponent();

            MainPage = new NavigationPage (new AreaPage());
            //MainPage = new NavigationPage(new AreaOffLine());
        }

		protected override void OnStart ()
		{
            // Handle when your app starts

        }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}

        public string AreaName
        {
            get
            {
                if (Properties.ContainsKey(TitleKey))
                    return Properties[TitleKey].ToString();
                return "";
            }
            set
            {
                Properties[TitleKey] = value;
            }
        }


    }
}

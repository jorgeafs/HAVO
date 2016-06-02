using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HAVO.Data;
using HAVO.Views;
using Xamarin.Forms;

namespace HAVO
{
	public class App : Application
	{
        static DatabaseHAVO database;
        public static DatabaseHAVO Database
        {
            get
            {
                database = database ?? new DatabaseHAVO();
                return database;
            }
        }
        public App ()
        {
            Resources = new ResourceDictionary();
            Resources.Add("primaryGreen", Color.FromHex("91CA47"));
            Resources.Add("primaryDarkGreen", Color.FromHex("6FA22E"));

            var nav = new NavigationPage(new MainView());
            nav.BarBackgroundColor = (Color)App.Current.Resources["primaryGreen"];
            nav.BarTextColor = Color.White;

            MainPage = nav;
        }
	}
}

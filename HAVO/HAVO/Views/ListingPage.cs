using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HAVO.Models;
using Xamarin.Forms;

namespace HAVO.Views
{
    public class ListingPage<T> : ContentPage
    {
        ListView listView;
        public ListingPage(int id)
        {
            Title = "Todo";

            NavigationPage.SetHasNavigationBar(this, true);

            listView = new ListView
            {
                RowHeight = 40,
                ItemTemplate = new DataTemplate(typeof(ItemCell))
            };
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

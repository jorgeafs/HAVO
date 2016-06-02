using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HAVO.Models;
using Xamarin.Forms;

namespace HAVO.Views
{
    public class ListingTasks : ContentPage
    {
        ListView listView;
        public ListingTasks(int id)
        {
            Title = "Todo";

            NavigationPage.SetHasNavigationBar(this, true);

            listView = new ListView
            {
                RowHeight = 40,
                ItemTemplate = new DataTemplate(typeof(ItemCell))
            };

            listView.ItemSelected += (sender, e) => {
                var task = (Task)e.SelectedItem;
                var taskPage = new TaskPage(task.ID);
                taskPage.BindingContext = task;
                Navigation.PushAsync(taskPage);
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

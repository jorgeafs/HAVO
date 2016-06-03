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
        int idLista;
        public ListingTasks(int listaId)
        {
            Title = "Showing Tasks";

            NavigationPage.SetHasNavigationBar(this, true);
            idLista = listaId;
            listView = new ListView
            {
                RowHeight = 40,
                ItemTemplate = new DataTemplate(typeof(ItemCell))
            };

            listView.ItemSelected += (sender, e) => {
                var task = (Task)e.SelectedItem;
                var taskPage = new TaskCreationPage(task.ID);
                taskPage.BindingContext = task;
                Navigation.PushAsync(taskPage);
            };

            var layout = new StackLayout();
            if (Device.OS == TargetPlatform.WinPhone)
            { // WinPhone doesn't have the title showing
                layout.Children.Add(new Label
                {
                    
                    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                    FontAttributes = FontAttributes.Bold
                });
            }
            layout.Children.Add(listView);
            layout.VerticalOptions = LayoutOptions.FillAndExpand;
            Content = layout;


            ToolbarItem tbi = null;
            if (Device.OS == TargetPlatform.iOS)
            {
                tbi = new ToolbarItem("+", null, () =>
                {
                    var lista = App.Database.getLista(idLista);
                    var taskPage = new TaskCreationPage(lista.ID);
                    Navigation.PushAsync(taskPage);
                }, 0, 0);
            }
            if (Device.OS == TargetPlatform.Android)
            { // BUG: Android doesn't support the icon being null
                tbi = new ToolbarItem("+", "plus", () =>
                {
                    var lista = App.Database.getLista(idLista);
                    var taskPage = new TaskCreationPage(lista.ID);
                    Navigation.PushAsync(taskPage);
                }, 0, 0);
            }

            if (Device.OS == TargetPlatform.WinPhone)
            {
                tbi = new ToolbarItem("Add", "add.png", () =>
                {
                    var lista = App.Database.getLista(idLista);
                    var taskPage = new TaskCreationPage(lista.ID);
                    Navigation.PushAsync(taskPage);
                }, 0, 0);
            }

            ToolbarItems.Add(tbi);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = App.Database.getTasks(idLista);
        }
    }
}

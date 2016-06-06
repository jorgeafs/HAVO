using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HAVO.Models;
using Xamarin.Forms;

namespace HAVO.Views
{
    public class ListingListas : ContentPage
    {
        ListView listView;
        public ListingListas()
        {
            Title = "Showing List";

            NavigationPage.SetHasNavigationBar(this, true);

            listView = new ListView
            {
                RowHeight = 40,
                ItemTemplate = new DataTemplate(typeof(ItemCell))
            };

            listView.ItemSelected += (sender, e) =>
            {
                var lista = (Lista)e.SelectedItem;
                var taskListing = new ListingTasks(lista.ID,true);
                Navigation.PushAsync(taskListing);
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
                    var lista = new Lista();
                    var listaCreatePage = new ListaCreatePage();
                    listaCreatePage.BindingContext = lista;
                    Navigation.PushAsync(listaCreatePage);
                }, 0, 0);
            }
            if (Device.OS == TargetPlatform.Android)
            { // BUG: Android doesn't support the icon being null
                tbi = new ToolbarItem("+", "plus", () =>
                {
                    var lista = new Lista();
                    var listaCreatePage = new ListaCreatePage();
                    listaCreatePage.BindingContext = lista;
                    Navigation.PushAsync(listaCreatePage);
                }, 0, 0);
            }

            if (Device.OS == TargetPlatform.WinPhone)
            {
                tbi = new ToolbarItem("Add", "add.png", () =>
                {
                    var lista = new Lista();
                    var listaCreatePage = new ListaCreatePage();
                    listaCreatePage.BindingContext = lista;
                    Navigation.PushAsync(listaCreatePage);
                }, 0, 0);
            }

            ToolbarItems.Add(tbi);

           
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = App.Database.getListas();
        }
    }
}
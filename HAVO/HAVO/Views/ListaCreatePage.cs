using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HAVO.Models;
using Xamarin.Forms;

namespace HAVO.Views
{
    public class ListaCreatePage : ContentPage
    {
        public ListaCreatePage()
        {
            this.SetBinding(ContentPage.TitleProperty, "Task");

            NavigationPage.SetHasNavigationBar(this, true);

            var saveButton = new Button { Text = "Save" };
            saveButton.IsEnabled = false;

            var createTaskButton = new Button { Text = "Create Tasks" };
            createTaskButton.IsEnabled = false;

            var titleLabel = new Label { Text = "Title" };
            var titleEntry = new Entry();
            titleEntry.SetBinding(Entry.TextProperty, "Title");
            titleEntry.TextChanged += (o, e) =>
            {
                saveButton.IsEnabled = true;
                createTaskButton.IsEnabled = true;
            };

            var detailLabel = new Label { Text = "Detail" };
            var detailEntry = new Entry();
            detailEntry.SetBinding(Entry.TextProperty, "Detail");
            detailEntry.TextChanged += (o, e) =>
            {
                saveButton.IsEnabled = true;
                createTaskButton.IsEnabled = true;
            };

            var projectLabel = new Label { Text = "Project" };
            var projectEntry = new Entry();
            projectEntry.SetBinding(Entry.TextProperty, "Project");
            projectEntry.TextChanged += (o, e) =>
            {
                saveButton.IsEnabled = true;
                createTaskButton.IsEnabled = true;
            };

            saveButton.Clicked += (sender, e) =>
            {
                var lista = (Lista)BindingContext;
                lista.Created = DateTime.Now;
                App.Database.SaveLista(lista);
                Navigation.PopAsync();
            };

            createTaskButton.Clicked += (sender, e) =>
            {
                var lista = (Lista)BindingContext;
                lista.Created = DateTime.Now;
                App.Database.SaveLista(lista);
                lista = (from listas in App.Database.getListas() select listas).LastOrDefault<Lista>();
                var listingPage = new ListingTasks(lista.ID,false);
                listingPage.BindingContext = lista;
                Navigation.PushAsync(listingPage);
            };

            var cancelButton = new Button { Text = "Cancel" };
            cancelButton.Clicked += (sender, e) =>
            {
                Navigation.PopAsync();
            };
            Content = new StackLayout {
                VerticalOptions = LayoutOptions.StartAndExpand,
                Padding = new Thickness(20),
                Children = {
                    titleLabel, titleEntry,
                    detailLabel, detailEntry,
                    projectLabel, projectEntry,
                    saveButton, createTaskButton
                    , cancelButton
                }
            };
        }

    }
}

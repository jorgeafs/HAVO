using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HAVO.Models;
using Xamarin.Forms;

namespace HAVO.Views
{
    public class TaskPage : ContentPage
    {
        public TaskPage(int listaID)
        {
            this.SetBinding(ContentPage.TitleProperty, "Task");

            NavigationPage.SetHasNavigationBar(this, true);

            var saveButton = new Button { Text = "Save" };
            saveButton.IsEnabled = false;

            var titleLabel = new Label { Text = "Title" };
            var titleEntry = new Entry();
            titleEntry.SetBinding(Entry.TextProperty, "Title");
            titleEntry.TextChanged += (o, e) => saveButton.IsEnabled = true;

            var criteriaLabel = new Label { Text = "Criteria" };
            var criteriaEntry = new Entry();
            criteriaEntry.SetBinding(Entry.TextProperty, "Criteria");
            criteriaEntry.TextChanged += (o, e) => saveButton.IsEnabled = true;

            var placementLabel = new Label { Text = "Placement" };
            var placementEntry = new Entry();
            placementEntry.SetBinding(Entry.TextProperty, "Placement");
            placementEntry.TextChanged += (o, e) => saveButton.IsEnabled = true;

            saveButton.Clicked += (sender, e) =>
            {
                var task = (Task)BindingContext;
                task.created = DateTime.Now;
                App.Database.SaveTask(task);
                Navigation.PopAsync();
            };

            var deleteButton = new Button { Text = "Delete" };
            deleteButton.IsEnabled = listaID == -1 ? false : true;
            deleteButton.Clicked += (sender, e) =>
            {
                var task = (Task)BindingContext;
                App.Database.DeleteTask(task.ID);
                Navigation.PopAsync();
            };

            var cancelButton = new Button { Text = "Cancel" };
            cancelButton.Clicked += (sender, e) =>
            {
                var task = (Task)BindingContext;
                Navigation.PopAsync();
            };
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.StartAndExpand,
                Padding = new Thickness(20),
                Children = {
                    titleLabel, titleEntry,
                    criteriaLabel, criteriaEntry,
                    placementLabel, placementEntry,
                    saveButton, deleteButton, cancelButton
                }
            };
        }

    }
}

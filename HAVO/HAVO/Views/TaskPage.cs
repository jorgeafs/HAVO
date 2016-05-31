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
		public TaskPage ()
		{
            this.SetBinding(ContentPage.TitleProperty, "Task");

            NavigationPage.SetHasNavigationBar(this, true);

            var titleLabel = new Label { Text = "Title" };
            var titleEntry = new Entry();
            titleEntry.SetBinding(Entry.TextProperty, "Title");

            var criteriaLabel = new Label { Text = "Criteria" };
            var criteriaEntry = new Entry();
            criteriaEntry.SetBinding(Entry.TextProperty, "Criteria");

            var placementLabel = new Label { Text = "Placement" };
            var placementEntry = new Entry();
            placementEntry.SetBinding(Entry.TextProperty, "Placement");

            

            var saveButton = new Button { Text = "Save" };
            saveButton.Clicked += (sender, e) => {
                var task = (Task)BindingContext;
                App.Database.SaveTask(task);
                Navigation.PopAsync();
            };

            var deleteButton = new Button { Text = "Delete" };
            deleteButton.Clicked += (sender, e) => {
                var todoItem = (TodoItem)BindingContext;
                App.Database.DeleteItem(todoItem.ID);
                Navigation.PopAsync();
            };

            var cancelButton = new Button { Text = "Cancel" };
            cancelButton.Clicked += (sender, e) => {
                var todoItem = (TodoItem)BindingContext;
                Navigation.PopAsync();
            };
            Content = new StackLayout {
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}

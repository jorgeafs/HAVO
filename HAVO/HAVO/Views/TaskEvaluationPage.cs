using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HAVO.Models;
using Xamarin.Forms;

namespace HAVO.Views
{
	public class TaskEvaluationPage : ContentPage
	{
        int idTask;
        Task task;
		public TaskEvaluationPage (int taskID)
		{
            idTask = taskID;
            Evaluation evaluation = new Evaluation();

            var titleLabel = new Label { Text = "Title" };
            var title = new Label { Text = task.Title };

            var detailLabel = new Label { Text = "Detail" };
            var detail = new Label { Text = task.Detail };

            var placementLabel = new Label { Text = "Placement" };
            var placement = new Label { Text = task.Placement };

            var criteriaLabel = new Label { Text = "Criteria" };
            var criteria = new Label { Text = task.Criteria };

            var doneLabel = new Label { Text = "Done" };
            var done = new Switch();
            done.SetBinding(Switch.IsToggledProperty, "Done");

            var commentsLabel = new Label { Text = "Comments" };
            var commentEntry = new Entry();
            commentEntry.SetBinding(Entry.TextProperty, "Comments");

            var saveButton = new Button { Text = "Save" };
            saveButton.IsEnabled = true;
            saveButton.Clicked += (sender, e) =>
            {
                evaluation = (Evaluation)BindingContext;
                evaluation.UserID = -1; ///While there are no user
                evaluation.TaskID = taskID;
                evaluation.DateChecked = DateTime.Now;
                App.Database.SaveCheck(evaluation);
                Navigation.PopAsync();
            };

            var cancelButton = new Button { Text = "Cancel" };
            cancelButton.IsEnabled = true;
            cancelButton.Clicked += (sender, e) =>
            {
                Navigation.PopAsync();
            };

            var titleStack = new StackLayout
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Padding = new Thickness(20),
                Children =
                {
                    titleLabel,
                    title
                }
            };

            var detailStack = new StackLayout
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Padding = new Thickness(20),
                Children =
                {
                    detailLabel,
                    detail
                }
            };

            var placementStack = new StackLayout
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Padding = new Thickness(20),
                Children =
                {
                    placementLabel,
                    placement
                }
            };

            var criteriaStack = new StackLayout
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Padding = new Thickness(20),
                Children =
                {
                    criteriaLabel,
                    criteria
                }
            };

            var buttonStack = new StackLayout
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Padding = new Thickness(20),
                Children =
                {
                    saveButton,
                    cancelButton
                }
            };

            Content = new StackLayout {
				Children = {
					titleStack,
                    detailStack,
                    placementStack,
                    criteriaStack,
                    commentsLabel,
                    commentEntry,
                    doneLabel,
                    done,
                    buttonStack
				}
			};
		}
        protected override void OnAppearing()
        {
            base.OnAppearing();
            task = App.Database.getTask(idTask);
        }
    }
}

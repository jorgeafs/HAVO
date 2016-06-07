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
		public TaskEvaluationPage (Task task)
		{
            Title = "Task Evaluation";
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

            var commentsLabel = new Label { Text = "Comments" };
            var commentEntry = new Entry();

            var saveButton = new Button { Text = "Save" };
            saveButton.IsEnabled = true;
            saveButton.Clicked += (sender, e) =>
            {
                evaluation.Done = done.IsToggled;
                evaluation.Comments = commentEntry.Text;
                evaluation.UserID = -1; ///While there are no user
                evaluation.TaskID = task.ID;
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
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Padding = new Thickness(10),
                Children =
                {
                    titleLabel,
                    title
                }
            };

            var detailStack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Padding = new Thickness(10),
                Children =
                {
                    detailLabel,
                    detail
                }
            };

            var placementStack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Padding = new Thickness(10),
                Children =
                {
                    placementLabel,
                    placement
                }
            };

            var criteriaStack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Padding = new Thickness(10),
                Children =
                {
                    criteriaLabel,
                    criteria
                }
            };

            var buttonStack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Padding = new Thickness(10),
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
    }
}

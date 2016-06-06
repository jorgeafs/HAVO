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
            Evaluation evaluation;
            Content = new StackLayout {
				Children = {
					new Label { Text = "Hello ContentPage" }
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

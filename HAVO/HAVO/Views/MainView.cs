using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using HAVO.Models;

using Xamarin.Forms;

namespace HAVO.Views
{
	public class MainView : ContentPage
	{
		public MainView ()
		{
            String title = "Menu Principal";
            String listaNueva = "Nueva lista";
            String listaCargar = "Cargar lista";
            String exit = "Salir";
            this.SetBinding(ContentPage.TitleProperty, title);

            var nuevaLista = new Button { Text = listaNueva };
            nuevaLista.Clicked += (sender, e) =>
            {
                var lista = new Lista();
                lista.UserID;
            };

            Content = new StackLayout {
				Children = {

                }
			};
		}
	}
}

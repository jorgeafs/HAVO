﻿using System;
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
            //String exit = "Salir";

            this.SetBinding(ContentPage.TitleProperty, title);

            var nuevaLista = new Button { Text = listaNueva };
            nuevaLista.Clicked += (sender, e) =>
            {
                var lista = new Lista();
                var listaCreatePage = new ListaCreatePage();
                ///lista.UserID;
                listaCreatePage.BindingContext = lista;
                Navigation.PushAsync(listaCreatePage);
            };

            var cargarListas = new Button { Text = listaCargar };
            cargarListas.Clicked += (sender, e) =>
            {
                var listas = App.Database.getListas();
                var listingListas = new ListingListas();
                listingListas.BindingContext = listas;
                Navigation.PushAsync(listingListas);
            };

            Content = new StackLayout {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Padding = new Thickness(20),
                Children = {
                    nuevaLista,
                    cargarListas
                }
			};
		}
	}
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaHM.Domain;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CinemaHM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResumePage : ContentPage
    {
        public ResumePage(Movie movie, Funcion funcion, int quantity)
        {
            InitializeComponent();
            MovieGrid.BindingContext = movie;
            FunctionGrid.BindingContext = funcion;
            Quantity.Text = quantity.ToString();
            TotalPay.Text = (quantity * funcion.Precio).ToString();
        }

        private async void PayClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Excelente", "La reserva se ha concretado", "OK");
            await Navigation.PushAsync(new BillboardPage());
        }
    }
}
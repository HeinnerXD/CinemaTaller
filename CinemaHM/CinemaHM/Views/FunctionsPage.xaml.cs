using System;
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
    public partial class FunctionsPage : ContentPage
    {
        private Movie movie;
        public FunctionsPage(Movie movie)
        {
            InitializeComponent();
            this.movie = movie;
            BindingContext = movie;
        }

        private async void FunctionSelected(object sender, SelectedItemChangedEventArgs e)
        {
            string quantity = Boletas.Text;
            if (string.IsNullOrEmpty(quantity))
            {
                await DisplayAlert("Validación", "Debe ingresar el numero de boletas", "OK");
                return;
            }
            int quan = Convert.ToInt32(quantity);
            var function = (Funcion)e.SelectedItem;

            await Navigation.PushAsync(new ResumePage(movie, function, quan));
        }
    }
}
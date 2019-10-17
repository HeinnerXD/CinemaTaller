using CinemaHM.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CinemaHM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BillboardPage : ContentPage
    {
        public BillboardPage()
        {
            InitializeComponent();
            LoadMovies();
        }

        private void LoadMovies()
        {
            //var webImage = new Image { Source = ImageSource.FromUri(new Uri("https://misapis.azurewebsites.net/Content/Images/venom.jpg")) };
            var moviesList = new List<Movie>
            {
                new Movie { Nombre = "Venom", FechaEstreno="Hoy", Genero = "Todos", Imagen="https://misapis.azurewebsites.net/Content/Images/venom.jpg", Recomendacion="Mayores de 7 años"},
                
            };



            lsMovies.ItemsSource = moviesList;
        }

        private async void MovieSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var contactSelected = (Movie)e.SelectedItem;
            //await Navigation.PushAsync(new FunctionsPage(MovieSelected));
        }
    }
}
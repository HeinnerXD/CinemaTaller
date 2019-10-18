using CinemaHM.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CinemaHM.Resources;

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

        private async void LoadMovies()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://misapis.azurewebsites.net");

            var request = await client.GetAsync("/api/Cartelera");
            if (request.IsSuccessStatusCode)
            {
                var responseJson = request.Content.ReadAsStringAsync().Result;
                var response = JsonConvert.DeserializeObject<List<Movie>>(responseJson);

                lsMovies.ItemsSource = response;
            }
            else
            {
                await DisplayAlert("UPS!", AppResources.ErrorCometido, "OK");
            }
        }

        private async void MovieSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var MovieSelected = (Movie)e.SelectedItem;
            await Navigation.PushAsync(new FunctionsPage(MovieSelected));
        }
    }
}
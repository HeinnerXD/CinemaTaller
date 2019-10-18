using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CinemaHM.Services;
using CinemaHM.Resources;

namespace CinemaHM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void Ingresar_Clicked(object sender, EventArgs e)
        {
            var user = txtUsuario.Text;
            var password = txtPassword.Text;

            if (string.IsNullOrEmpty(user))
            {
                await DisplayAlert(AppResources.Validacion, AppResources.UsuarioRequerido, "OK");
                txtUsuario.Focus();
                return;
            }
            if (string.IsNullOrEmpty(password))
            {
                await DisplayAlert(AppResources.Validacion, AppResources.ContraseñaRequerida, "OK");
                txtPassword.Focus();
                return;
            }
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://misapis.azurewebsites.net");

            var authentication = new AuthenticationService
            {
                Usuario = user,
                Password = password
            };

            string json = JsonConvert.SerializeObject(authentication);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = await client.PostAsync("/api/Seguridad", content);
            if (request.IsSuccessStatusCode)
            {
                var responseJson = request.Content.ReadAsStringAsync().Result;
                var response = JsonConvert.DeserializeObject<Response>(responseJson);

                if (response.EsPermitido)
                {
                    await Navigation.PushAsync(new BillboardPage());
                }
                else
                {
                    await DisplayAlert(AppResources.Invalido, response.Mensaje, "OK");
                }
            }
            else
            {
                await DisplayAlert("UPS!", AppResources.ErrorCometido, "OK");
            }
        }
    }
}
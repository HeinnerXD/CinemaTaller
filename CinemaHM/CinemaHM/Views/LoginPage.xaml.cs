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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Ingresar_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                DisplayAlert("Validacion", "El nombre de usuario es requerido", "OK");
                txtUsuario.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(txtPassword.Text))
            {
                DisplayAlert("Validacion", "La contraseña es requerida", "OK");
                txtPassword.Focus();
                return;
            }
            else if (txtUsuario.Text == "Admin" && txtPassword.Text == "CinemaAdmin")
            {
                Navigation.PushAsync(new BillboardPage());
            }
            else
            {
                DisplayAlert("Validacion", "Credenciales Incorrectas", "OK");
                return;
            }
        }
    }
}
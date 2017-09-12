using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Champion.Services;

namespace Champion
{
    public partial class MainPage : ContentPage
    {

        ApiServices apiServices = new ApiServices();
        public string Email { get; set; }
        public string Password { get; set; }
        public string Message { get; set; }

        public MainPage()
        {
            InitializeComponent();
            indicator.IsRunning = false;
        }
        private void register_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new Register();       
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            App.Current.MainPage = new Register();
        }

        private async void login_Clicked(object sender, EventArgs e)
        {
            indicator.IsRunning = true;
            Email = username.Text;
            Password = password.Text;
            var isSuccess = await apiServices.LoginAsync(Email, Password);
            //indicator.IsRunning = false;
            if (isSuccess==0)
            {
                Message = "Login Succesful";
                await DisplayAlert("Alert",Message , "OK");
                App.Current.MainPage = new MasterPage();

            }
            else if (isSuccess==1)
            {
                Message = "Invalid Username";
            }
            else
            {
                Message = "Invalid Password";
            }
        }
    }
}

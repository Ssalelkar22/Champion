using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Champion
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Register : ContentPage
	{
        public Register()
        {
            InitializeComponent();

            gym.Items.Add("All Star Test Gym");
        }

        private void login_Clicked(object sender, EventArgs e)
        {
           // App.Current.MainPage = new MainPage();
        }
    }
}
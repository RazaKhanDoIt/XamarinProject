using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Navigation
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }


        

        private async void Login_Clicked(object sender, EventArgs e)
        {
                if (DataSource.Login(txtuserName.Text , txtpassword.Text))
            {
                 await Navigation.PushAsync(new UserPage());
            }
                else
            {
              await DisplayAlert ("Alert", "Invalid username or password", "Ok");
            }
        }

        private async void btnSignup_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }
    }
}

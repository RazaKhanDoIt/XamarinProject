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
            if (await LoginAsync(txtuserName.Text , txtpassword.Text))
            {
                txtuserName.Text = "";
                txtpassword.Text = "";

                 await Navigation.PushAsync(new UserPage());
            }
            else
            {
              await DisplayAlert ("Alert", "Invalid username or password", "Ok");
            }
        }

        private  async Task<bool> LoginAsync(string username,string password)
        {
            foreach (User user in await App.Database.GetUsersAsync())
            {
                if(user.Username == username && user.Password == password)
                {
                    return true;
                }
            }
            return false;
        }

        private async void btnSignup_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }
    }
}

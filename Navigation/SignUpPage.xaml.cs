using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Navigation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
       


        public SignUpPage()
        {
            InitializeComponent();
           
            
        }

        private void btnCancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private async void btnCreate_Clicked(object sender, EventArgs e)
        {
            bool fieldsEmpty = txtUsername.Text == "" || txtPassword.Text == "" || txtPasswordRep.Text == "";
            bool passwordMatch = txtPassword.Text == txtPasswordRep.Text;
            if(fieldsEmpty)
            {
                await DisplayAlert("Alert", "Fields cannot be empty", "OK");
            }
            else
            {
             
                    if (passwordMatch)
                    {
                        if (await CreateUserAsync(txtUsername.Text,txtPassword.Text))
                        {
                            await DisplayAlert("Alert", $"User {txtUsername.Text} was created!", "OK");
                            await Navigation.PopAsync();
                        }

                        else
                        {

                            await DisplayAlert("Alert", "Username already used!", "Ok");
                        }
                    }
                    else
                    {
                        await DisplayAlert("Alert", "Passwords do not Match", "ok");
                    }
                }
                            
            }
        private async Task<bool> CreateUserAsync(string username, string password)
        {
            foreach (User user in await App.Database.GetUsersAsync())
            {
                if (user.Username == username)
                {
                    return false;
                }
            }

             await App.Database.SaveUserAsync(
                new User
                {
                    Username = username,
                    Password = password
                });

            return true;
        }
        
        
    }
}

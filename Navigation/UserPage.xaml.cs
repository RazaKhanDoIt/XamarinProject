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
    public partial class UserPage : ContentPage
    {
        public UserPage()
        {
            InitializeComponent();
           
            dpDate.MinimumDate = DateTime.Now;
            pickerUser.ItemsSource = DataSource.GetUsers();
            pickerUser.SelectedIndex = 0;


            listTasks.ItemsSource = DataSource.GetTasks();
        }

        private async void btnAddTask_Clicked(object sender, EventArgs e)
        {
            bool fieldsEmpty = txtTaskId.Text == "" || txtDescription.Text == "";
            if(fieldsEmpty)
            {
                await DisplayAlert("Alert", "Fields cannot be empty", "OK");
            }
            else
            {
                User temp = (User)pickerUser.SelectedItem;
                if(DataSource.AddTask(new Task(txtTaskId.Text,txtDescription.Text,temp.Username,dpDate.Date)))
                {
                   
                    await DisplayAlert("Alert", $"Task {txtTaskId.Text} was created", "ok");
                    pickerUser.SelectedIndex = 0;
                    txtTaskId.Text = "";
                    txtDescription.Text = "";
                    dpDate.Date = DateTime.Now;
                }
                else
                {
                    await DisplayAlert("Alert", "Task id already exists", "OK");
                }
            }
        }

        private void btnLogout_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private  void listTasks_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
            var taskDetail = new TaskDetailPage(DataSource.GetTasks()[e.SelectedItemIndex]);
            taskDetail.BindingContext = DataSource.GetTasks()[e.SelectedItemIndex];
            Navigation.PushAsync(taskDetail);
        }
    }
}
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
            DataSource.AddTask(new Task("OUDS-2811", "Update Ios 12", "RazaKhan", new DateTime(2022, 7, 23)));
            DataSource.AddTask(new Task("OUDS-2821", "Fix Rocket", "Alex Sekki", new DateTime(2022, 5, 23)));
            DataSource.AddTask(new Task("OUDS-222", "Run Project", "Shaun Slobers", new DateTime(2022, 6, 12)));
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
                if(DataSource.AddTask(new Task(txtTaskId.Text,txtDescription.Text,pickerUser.SelectedItem.ToString(),dpDate.Date)))
                {
                    await DisplayAlert("Alert", $"Task {txtTaskId.Text} was created", "ok");
                }
                else
                {
                    await DisplayAlert("Alert", "Task id already exists", "OK");
                }
            }
        }
    }
}
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
    public partial class TaskDetailPage : ContentPage
    {
        

        public TaskDetailPage(Task tsk)
        {
            InitializeComponent();
            dpDate.Date = Convert.ToDateTime(tsk.DeadLine);
            pickerUser.ItemsSource = DataSource.GetUsers();
            //this is the same to user as method UserIndex() inside dataSource
            int index = DataSource.GetUsers().FindIndex(item => item.Username == tsk.Assigned);
            pickerUser.SelectedIndex = index;
            txtTaskId.IsEnabled = false;
        }

        private async void btnEdit_Clicked(object sender, EventArgs e)
        {
            bool emptyFields = txtDescription.Text == "";
            if(emptyFields)
            {
                await DisplayAlert("Alert", "You have an empty field.. Please correct", "ok");
            }
            else
            {
                User temp = (User)pickerUser.SelectedItem;
                if(DataSource.EditTask(new Task(txtTaskId.Text,txtDescription.Text,temp.Username,dpDate.Date)))
                {
                    await DisplayAlert("Alert", $"Task {txtTaskId.Text} was edited", "OK");
                }
                else
                {
                    await DisplayAlert("Alert", $"Error on trying to edit {txtTaskId.Text}", "Ok");
                }
            }
            await Navigation.PopAsync();
        }

        private void btnCancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private async void btnDelete_Clicked(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Alert", "Are you sure? Delete cannot be undone", "Yes", "No");
            if( answer)
            {
                DataSource.DeleteTask(txtTaskId.Text);
                await Navigation.PopAsync();
            }
        }
    }
}
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Navigation
{
    public partial class App : Application
    {
        static Database database;

        internal static Database Database
        {
            get{
                if (database == null){
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "users.db3"));

                }
                return database;
            }
        }


        public App()
        {
            InitializeComponent();


           DataSource.AddTask(new Task("OUS-2891", "Update", "SteveJobs", new DateTime(2022, 7, 23)));
           DataSource.AddTask(new Task("OUS-2822", "Fix Rocket", "ElonMusk", new DateTime(2022, 5, 22)));
            DataSource.AddTask(new Task("OUS-1923", "Sync Machine Test", "Tesla", new DateTime(2022, 6, 12)));
          //  DataSource.AddUser(new User("ElonMusk", "123"));
            //DataSource.AddUser(new User("SteveJobs", "123"));
            //DataSource.AddUser(new User("Tesla", "123"));
            //DataSource.AddUser(new User("Raza", "123"));
           



            MainPage = new  NavigationPage(new MainPage());
        }

        protected async override void OnStart()
        {
            //await App.Database.SaveUserAsync(
            //    new User{
            //        Username ="SteveJobs",
            //        Password = "123"
            //    });

            //await App.Database.SaveUserAsync(
            //  new User
            //  {
            //      Username = "ElonMusk",
            //      Password = "123"
            //  });

            //await App.Database.SaveUserAsync(
            //  new User
            //  {
            //      Username = "Tesl",
            //      Password = "123"
            //  });


        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

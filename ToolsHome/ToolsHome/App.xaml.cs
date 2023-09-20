using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ToolsHome.Views;
using ToolsHome.Services;
using Xamarin.Essentials;

namespace ToolsHome
{
    public partial class App : Application
    {
        public static DatabaseContext DatabaseApplication { get; set; }
        public App()
        {
            InitializeComponent();

            InitalizeDatabase();

            MainPage = new NavigationPage(new HomePage());
        }

        private void InitalizeDatabase()
        {
            var folderApplication = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var uri = System.IO.Path.Combine(folderApplication, "Tarea.db3");

            DatabaseApplication = new DatabaseContext(uri);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

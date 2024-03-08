using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BMIapp
{
    public partial class App : Application
    {
        static Database db;

        public static Database database
        {
            get
            {
                if (db == null)
                    db = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "baza.txt"));

                return db;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
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

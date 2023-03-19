using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace P4EXAMEN119020051
{
    public partial class App : Application
    {
        static Controllers.LocalizacionController database;

        public static Controllers.LocalizacionController Database
        {
            get
            {
                if (database == null)
                {
                    var pathdatabase = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    var dbname = "P4EXAMEN119020051";
                    var fullpath = Path.Combine(pathdatabase, dbname);
                    database = new Controllers.LocalizacionController(fullpath);
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();


            MainPage = new NavigationPage(new Views.PageLocalizacion());
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

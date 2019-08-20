using AppJaveriana.Views;
using MVVMXamarin.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppJaveriana
{
    public partial class App : Application
    {
        //Attributes

        private static DataBase bd;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginView());
        }

        //Metodos
        public static DataBase DB
        {
            get
            {
                if (bd == null)
                {
                    bd = new DataBase(Constantes.NombreBD);
                }
                return bd;
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

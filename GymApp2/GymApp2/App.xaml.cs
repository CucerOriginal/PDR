using GymApp;
using GymApp.Views;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GymApp2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            string key = Preferences.Get("Key", String.Empty);
            if (String.IsNullOrEmpty(key))
            {
                MainPage = new LoginView();
            }
            else
            {
                MainPage = new AppShell();
            }
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

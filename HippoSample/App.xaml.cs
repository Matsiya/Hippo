using System.Collections.Generic;
using Hippo.Abstraction;
using Hippo.Implementation;
using HippoSample.Models;
using Xamarin.Forms;

namespace HippoSample
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();


            // Initialiaze all the stores you wish to store and use in the app
            var sesstion = new StoreServiceInitializer();

            // Choose which type of storage to use
            HippoCurrent.StorageType = StorageType.LocalMachine;

            MainPage = new NavigationPage(new HippoSamplePage(){ Title = "Hippo" }){ BarTextColor = Color.White, BarBackgroundColor = Color.RoyalBlue };

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

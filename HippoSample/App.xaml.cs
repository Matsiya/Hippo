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

            new StoreServiceInitializer();

            MainPage = new HippoSamplePage();

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

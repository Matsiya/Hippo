using Hippo.Abstraction;
using Xamarin.Forms;
using HippoSample.Models;
using Hippo.Implementation;
using System.Collections.Generic;

namespace HippoSample
{
    public partial class HippoSamplePage : ContentPage
    {
        public HippoSamplePage()
        {
            InitializeComponent();

          
            var store = new BaseStore<Session>();
         
            store.GetMethod = async() => 
            {              
                await System.Threading.Tasks.Task.Delay(2000);
                return new Session();
            };

            store.PutMethod = (obj) => 
            {
                
            };


            HippoCurrent.StoreManager.AddStore(store);


            var my_store =  HippoCurrent.StoreManager.GetStore<Session>();


        }

    }
}

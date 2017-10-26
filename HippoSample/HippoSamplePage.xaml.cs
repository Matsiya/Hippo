using Hippo.Abstraction;
using Xamarin.Forms;
using HippoSample.Models;
using Hippo.Implementation;
using System.Collections.Generic;
using System;

namespace HippoSample
{
    public partial class HippoSamplePage : ContentPage
    {
        BaseStore<Session> my_store;

        public HippoSamplePage()
        {
            InitializeComponent();

            my_store = HippoCurrent.StoreManager.GetStore<Session>();

            Get();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        async void Get()
        {
            var item = await my_store.GetItemAsync("1");

            if (item.Item1 != null)
            {
                outputLabel.Text =  (item.Item2 ? "Server: " : "Local: ") + item.Item1.Name;
            }
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(entryField.Text))
            {
                var response = await my_store.InsertAsync("1",new Session(){ Id = 1, DateCreated = DateTime.Now, Name = entryField.Text });

                if(response){

                    var item = await my_store.GetItemAsync("1");
                   
                    if(item.Item1 != null)
                    {
                        outputLabel.Text = (item.Item2 ? "Server: " : "Local: ") + item.Item1.Name;
                        entryField.Text = "";
                    }
                }
            } 
        }
    }
}

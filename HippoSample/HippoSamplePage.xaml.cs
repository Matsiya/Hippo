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
        
        Store<Session> sessionStore = HippoCurrent.StoreManager.GetStore<Session>();


        public HippoSamplePage()
        {
            InitializeComponent();

            Get();
        }

    
        async void Get()
        {
            var item = await sessionStore.GetItemAsync("1");

            if (item != null)
            {
                outputLabel.Text = item.Name;
            }
        }


        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(entryField.Text))
            {
                var response = await sessionStore.InsertAsync("1",new Session(){ Id = 1, DateCreated = DateTime.Now, Name = entryField.Text });

                if(response){

                    var item = await sessionStore.GetItemAsync("1");
                   
                    if(item != null)
                    {
                        outputLabel.Text =  item.Name;
                        entryField.Text = "";
                    }
                }
            } 
        }


    }
}

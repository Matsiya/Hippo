using System;
using Hippo.Abstraction.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Hippo.Abstraction
{
    
    internal class Network : INetwork
    {
        
        public Network()
        {
            Plugin.Connectivity.CrossConnectivity.Current.ConnectivityChanged += Current_ConnectivityChanged;
        } 


        public  bool IsOnline { get { return Plugin.Connectivity.CrossConnectivity.Current.IsConnected; } }


        void Current_ConnectivityChanged(object sender, Plugin.Connectivity.Abstractions.ConnectivityChangedEventArgs e)
        {
            if (e.IsConnected)
                OnConnected();
            else
                OnDisconnected();
        }

        public virtual void OnConnected()
        {
           
        }

        public virtual void OnDisconnected()
        {
            
        }

    }
}

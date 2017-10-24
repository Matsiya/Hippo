using System;
using Hippo.Abstraction.Interfaces;

namespace Hippo.Abstraction
{
    
    internal class Network : INetwork
    {
        
        public Network()
        {
            Plugin.Connectivity.CrossConnectivity.Current.ConnectivityChanged += Current_ConnectivityChanged;
        }


        void Current_ConnectivityChanged(object sender, Plugin.Connectivity.Abstractions.ConnectivityChangedEventArgs e)
        {
            
        }

        public void OnConnected()
        {
           
        }

        public void OnDisconnected()
        {
            
        }

        public void OnNetworkChange()
        {
            
        }


    }
}

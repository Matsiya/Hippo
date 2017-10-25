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

        private bool isOnline;
        public bool IsOnline { get { return isOnline; } private set
            {
                isOnline = value;

                if (isOnline)
                    OnConnected();
                else
                    OnDisconnected();

            } }

        public bool CanSync { get; private set; }


        void Current_ConnectivityChanged(object sender, Plugin.Connectivity.Abstractions.ConnectivityChangedEventArgs e)
        {
            if (e.IsConnected)
                IsOnline = true;
            else
                IsOnline = false;
        }


        public virtual void OnConnected()
        {
           
        }

        public virtual void OnDisconnected()
        {
            
        }

        public virtual void OnNetworkChange()
        {
            
        }


    }
}

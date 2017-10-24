using System;

namespace Hippo.Abstraction.Interfaces
{
    internal interface INetwork
    {
        
        void OnNetworkChange();

        void OnConnected();

        void OnDisconnected();

    }
}

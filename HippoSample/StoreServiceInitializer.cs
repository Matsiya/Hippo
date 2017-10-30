using System;
using Hippo.Abstraction;
using Hippo.Implementation;
using HippoSample.Models;
using HippoSample.Services;

namespace HippoSample
{
    public class StoreServiceInitializer
    {
        
        public StoreServiceInitializer()
        {
            var store = new Store<Session>(){ };
            attachStoreSession(store);

            HippoCurrent.StoreManager.AddStore(store);
        }

        void attachStoreSession(Store<Session> store)
        {
            var service = new SessionService();

            store.GetItemMethod = (arg) => service.GetItemAsync(arg);
            store.PutItemMethod = (arg) => service.InsertAsync(arg.Id.ToString(),arg);
            // And so on
        }



    }
}

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

            var tennis = new Store<Tennis>();
            attachTennisSession(tennis);

            HippoCurrent.StoreManager.AddStore(store);
            HippoCurrent.StoreManager.AddStore(tennis);
        }

        void attachStoreSession(Store<Session> store)
        {
            var service = new SessionService();

            store.GetItemMethod = (arg) => service.GetItemAsync(arg);
            store.PutItemMethod = (arg) => service.InsertAsync(arg.id,arg);
            // And so on
        }

        void attachTennisSession(Store<Tennis> store)
        {
            var service = new TennisService();

            store.GetItemMethod = (arg) => service.GetItemAsync(arg);
            store.PutItemMethod = (arg) => service.InsertAsync(arg.id, arg);
            // And so on
        }

    }
}

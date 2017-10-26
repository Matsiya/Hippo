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
            var store = new BaseStore<Session>();
            attachStoreSession(store);

            HippoCurrent.StoreManager.AddStore(store);
        }

        void attachStoreSession(BaseStore<Session> store)
        {
            var service = new SessionService();

            store.GetItemMethod = (arg) => service.GetItemAsync(arg);
            store.PutItemMethod = (arg) => service.InsertAsync(arg.Id.ToString(),arg);
            // And so on
        }



    }
}

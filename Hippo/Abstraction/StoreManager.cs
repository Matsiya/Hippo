using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections;
using Hippo.Abstraction.Interfaces;
using System.Linq;

namespace Hippo.Abstraction
{

    public class StoreManager : IStoreManager
    {

        private List<Object> Stores = new List<Object>();

        public void AddStore<T>(Store<T> Store) where T : BaseTable
        {           
            if (Stores.Contains(Store))
                return;

            Stores.Add(Store);
        }

        public Store<T> GetStore<T>()  where T : BaseTable
        {
            var _stores = Stores.Where( (arg) => arg.GetType() == typeof(Store<T>));

            if(_stores.Any())
            {
                return _stores.FirstOrDefault() as Store<T>;
            }
            else
            {
                return null; 
            }
        }

        public Task<bool> SyncAll()
        {
            throw new NotImplementedException();
        }

    }
}

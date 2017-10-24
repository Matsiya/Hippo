using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Hippo.Abstraction.Interfaces;

namespace Hippo.Abstraction
{
    public class StoreManager : IStoreManager
    {
     



        public void AddStore<T>(IBaseStore<T> Store) where T : BaseTable
        {
            throw new NotImplementedException();
        }

       
        public void RemoveStore<T>(IBaseStore<T> Store) where T : BaseTable
        {
            throw new NotImplementedException();
        }


        public void GetStore<T>() 
        {
            throw new NotImplementedException();
        }


        public Task<bool> SyncAll()
        {
            throw new NotImplementedException();
        }


    }
}

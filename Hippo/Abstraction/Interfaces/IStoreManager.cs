using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hippo.Abstraction.Interfaces
{
    
    public interface IStoreManager
    {
     
        void AddStore<T>(Store<T> Store) where T : BaseTable;

       
        Store<T> GetStore<T>() where T : BaseTable;


        Task<bool> SyncAll();

    }
}

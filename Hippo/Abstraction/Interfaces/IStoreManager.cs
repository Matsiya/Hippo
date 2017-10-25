using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hippo.Abstraction.Interfaces
{
    
    public interface IStoreManager
    {
     
        void AddStore<T>(IBaseStore<T> Store) where T : BaseTable;

        //void RemoveStore<T>(IBaseStore<T> Store) where T : BaseTable;


        T GetStore<T>();


        Task<bool> SyncAll();


    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hippo.Abstraction.Interfaces
{
    
    public interface IBaseStore<T> where T : BaseTable
    {
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
      
        Task<T> GetItemAsync(string id);

        Task<bool> InsertAsync(T item);

        Task<bool> UpdateAsync(T item);

        Task<bool> RemoveAsync(T item);

        Task<bool> SyncAsync();
    }

}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hippo.Abstraction.Interfaces
{
    
    public interface IBaseStore<T> where T : BaseTable
    {
        Task<Tuple<IEnumerable<T>,bool>> GetItemsAsync(bool forceRefresh = false);
      
        Task<Tuple<T,bool>> GetItemAsync(string id,bool forceRefresh = false);

        Task<bool> InsertAsync(string id,T item,bool forceRefresh = false);

        Task<bool> UpdateAsync(string id,T item,bool forceRefresh = false);

        Task<bool> RemoveAsync(string id,T item,bool forceRefresh = false);

        Task<bool> SyncAsync();
    }

}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hippo.Abstraction.Interfaces
{
    
    public interface IBaseStore<T> where T : BaseTable
    {
        Task<Tuple<IEnumerable<T>,bool>> GetItemsAsync(bool forceRefresh = false);
      
        Task<T> GetItemAsync(string id);

        Task<bool> InsertAsync(string id,T item );

        Task<bool> UpdateAsync(string id,T item );

        Task<bool> RemoveAsync(string id );

        Task<bool> SyncAsync();
    }

}

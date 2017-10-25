using System;
using System.Threading.Tasks;
using Hippo.Abstraction.Interfaces;
using Akavache;
using System.Reactive.Linq;

namespace Hippo.Abstraction
{
    public class BaseStore<T> : IBaseStore<T>  where T : BaseTable
    {

        public Func<Task<T>> GetMethod { get; set; }

        public Action<T> PutMethod { get; set; }


        public Task<T> GetItemAsync(string id)
        {
            
            var s = GetMethod.Invoke();

            throw new NotImplementedException();
        }

        public Task<System.Collections.Generic.IEnumerable<T>> GetItemsAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertAsync(T item)
        {
            PutMethod.Invoke(item);

            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(T item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SyncAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(T item)
        {
            throw new NotImplementedException();
        }

    }
}

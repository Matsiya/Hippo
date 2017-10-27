using System;
using System.Threading.Tasks;
using Hippo.Abstraction.Interfaces;
using Akavache;
using System.Collections.Generic;
using System.Reactive.Linq;

namespace Hippo.Abstraction
{
    public class BaseStore<T> : IBaseStore<T>  where T : BaseTable
    {
        

        public Func<string,Task<T>> GetItemMethod { get; set; }

        public Func<T,Task<T>> PutItemMethod { get; set; }

        public Func<Task<IEnumerable<T>>> GetAllItemsMethod { get; set; }

        public Func<T, Task<bool>> RemoveMethod { get; set; }

        public Func<T, Task<T>> UpdateMethod { get; set; }



        public async Task<T> GetItemAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return null;

            var response = await BaseStorage.GetItemAsync<T>(id);
            return response;
        }


        public async Task<Tuple<IEnumerable<T>,bool>> GetItemsAsync(bool forceRefresh = false)
        {
            if (forceRefresh)
            {
                return null; // TODO
            }
            else
            {
                var response = await BaseStorage.GetAllItemsAsync<T>();
                return new Tuple<IEnumerable<T>, bool>(response, false );
            }
        }


        public async Task<bool> InsertAsync(string id, T item)
        {
            if (string.IsNullOrWhiteSpace(id) || item == null)
                return false;

            var response = await BaseStorage.InsertItemAsync<T>(id, item);
            return response;
        }


        public async Task<bool> RemoveAsync(string id )
        {
            if (string.IsNullOrWhiteSpace(id))
                return false;

            var response = await BaseStorage.RemoveItemAsync<T>(id);
            return response;
        }



        public async Task<bool> UpdateAsync(string id,T item )
        {
            if (string.IsNullOrWhiteSpace(id) || item == null)
                return false;

            var response = await BaseStorage.InsertItemAsync<T>(id,item);
            return response;
        }


        public Task<bool> SyncAsync()
        {
            throw new NotImplementedException();
        }

    }
}

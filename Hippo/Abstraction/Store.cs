using System;
using System.Threading.Tasks;
using Hippo.Abstraction.Interfaces;
using Akavache;
using System.Collections.Generic;
using System.Reactive.Linq;
using Hippo.Implementation;

namespace Hippo.Abstraction
{
    public class Store<T> : IBaseStore<T>  where T : BaseTable
    {


        public Func<string,Task<T>> GetItemMethod { get; set; }

        public Func<T,Task<T>> PutItemMethod { get; set; }

        public Func<Task<IEnumerable<T>>> GetAllItemsMethod { get; set; }

        public Func<T, Task<bool>> RemoveMethod { get; set; }

        public Func<T, Task<T>> UpdateMethod { get; set; }

        public bool IsOnlineOnly { get; set; }


        /// <summary>
        /// Gets an item from the local database for a given ID. If item is not in local data, returns item from the server and stores in the local data
        /// </summary>
        public async Task<T> GetItemAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return null;
            
            var response = await BaseStorage.GetItemAsync<T>(id);

            if(response==null)
            {
                
            }

            return response;
        }


        /// <summary>
        /// Gets all the items for the given type from local data. If force refresh is true, fetches the latest items from the server and stores them in the local data.
        /// </summary>
        public async Task<Tuple<IEnumerable<T>,bool>> GetItemsAsync(bool forceRefresh = false)
        {
            if (forceRefresh)
            {
                return null; // TODO 
            }
            else
            {
                var response = await BaseStorage.GetAllItemsAsync<T>();

                if (response == null)
                {

                }

                return new Tuple<IEnumerable<T>, bool>(response, false );
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public async Task<bool> InsertAsync(string id, T item)
        {
            if (string.IsNullOrWhiteSpace(id) || item == null)
                return false;

            var response = await BaseStorage.InsertItemAsync<T>(id, item);
            return response;
        }


        /// <summary>
        /// 
        /// </summary>
        public async Task<bool> RemoveAsync(string id )
        {
            if (string.IsNullOrWhiteSpace(id))
                return false;

            var response = await BaseStorage.RemoveItemAsync<T>(id);
            return response;
        }


        /// <summary>
        /// 
        /// </summary>
        public async Task<bool> UpdateAsync(string id,T item )
        {
            if (string.IsNullOrWhiteSpace(id) || item == null)
                return false;

            var response = await BaseStorage.InsertItemAsync<T>(id,item);
            return response;
        }


        /// <summary>
        /// 
        /// </summary>
        public Task<bool> SyncAsync()
        {
            throw new NotImplementedException();
        }

    }
}

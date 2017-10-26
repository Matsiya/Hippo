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



        public async Task<Tuple<T,bool>> GetItemAsync(string id, bool forceRefresh = false)
        {
            
            if (forceRefresh)
            {
                var response = await GetItemMethod.Invoke(id);

                await InsertAsync(id,response);

                return new Tuple<T, bool>(response, true);
            }
            else
            {
                var response = await BaseStorage.GetItemAsync<T>(id);
                return new Tuple<T, bool>(response, false);
            }
           
        }

        public Task<Tuple<IEnumerable<T>,bool>> GetItemsAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> InsertAsync(string id,T item, bool forceRefresh = false)
        {
            if (forceRefresh)
            {
                var response = await PutItemMethod.Invoke(item);
                             
                var local_response = await BaseStorage.InsertItemAsync<T>(id, response);
                return local_response;
            }
            else
            {
                var response = await BaseStorage.InsertItemAsync<T>(id, item);
                return response;
            }
        }


        public Task<bool> RemoveAsync(string id,T item, bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }



        public Task<bool> UpdateAsync(string id,T item, bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }



        public Task<bool> SyncAsync()
        {
            throw new NotImplementedException();
        }

    }
}

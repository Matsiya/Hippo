using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Reactive.Linq;
using Akavache;
using System.Collections;

namespace Hippo.Abstraction
{
    
    internal static class BaseStorage
    {           

        private static IBlobCache Storage = BlobCache.LocalMachine;


        public static async Task<T> GetItemAsync<T>(string id) where T : BaseTable
        {
            try
            {
                var response = await Storage.GetObject<T>(id);
                return response;
            }
            catch(KeyNotFoundException ex)
            {
                return null;
            }
        }

        public static async Task<bool> InsertItemAsync<T>(string id, T item) where T : BaseTable
        {
            try
            {
                var response = await Storage.InsertObject(id, item);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public static async Task<IEnumerable<T>> GetAllItemsAsync<T>() where T : BaseTable
        {
            try
            {
                var response = await Storage.GetAllObjects<T>();
                return response;
            }
            catch(KeyNotFoundException ex)
            {
                return null;
            }
        }


        public static async Task<bool> RemoveItemAsync<T>(string id) where T : BaseTable
        {
            try
            {
                var response = await Storage.InvalidateObject<T>(id);
                return true;
            }
            catch(KeyNotFoundException key)
            {
                return false;
            }
        }


    }
}

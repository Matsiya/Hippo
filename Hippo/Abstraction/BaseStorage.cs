using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Reactive.Linq;
using Akavache;
using System.Collections;
using Newtonsoft.Json;
using Hippo.Implementation;
using Hippo.Abstraction.Interfaces;

namespace Hippo.Abstraction
{
    
    internal static class BaseStorage
    {

        private const string QString = "PendingOperations";

        internal static IBlobCache Storage = HippoCurrent.StorageType == StorageType.LocalMachine ? BlobCache.LocalMachine : HippoCurrent.StorageType == StorageType.UserAccount ? BlobCache.UserAccount : BlobCache.Secure;

        internal static void ChangeStorage()
        {
            Storage = HippoCurrent.StorageType == StorageType.LocalMachine ? BlobCache.LocalMachine : HippoCurrent.StorageType == StorageType.UserAccount ? BlobCache.UserAccount : BlobCache.Secure;
        }

        public static async Task<T> GetItemAsync<T>(string id) where T : BaseTable
        {
            try
            {
                var response = await Storage.GetObject<T>(id);

                return response;
            }
            catch(KeyNotFoundException)
            {
                return null;
            }
        }


        public static async Task<bool> InsertItemAsync<T>(string id, T item) where T : BaseTable
        {
            try
            {
                
                var date_create = await Storage.GetObjectCreatedAt<T>(id);
                               
                var response = await Storage.InsertObject(id, item);

                if (date_create == null)
                {
                    HippoCurrent.Queue.Add(new QueueItem<T>(id, OperationType.Insert));
                }
                else
                {
                    HippoCurrent.Queue.Add(new QueueItem<T>(id, OperationType.Update));
                }

                return true;
            }
            catch(Exception)
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
            catch(KeyNotFoundException)
            {
                return null;
            }
        }


        public static async Task<bool> RemoveItemAsync<T>(string id) where T : BaseTable
        {
            try
            {
                var response = await Storage.InvalidateObject<T>(id);

                HippoCurrent.Queue.Add(new QueueItem<T>(id, OperationType.Remove));

                return true;
            }
            catch(KeyNotFoundException)
            {
                return false;
            }
        }


        public static async Task<Queue<IQueueItem>> GetQueue()
        {
            try
            {
                var response = await BlobCache.LocalMachine.GetObject<string>(QString);
                return  JsonConvert.DeserializeObject<Queue<IQueueItem>>(response);             
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }

        public static async Task<bool> SaveQueue(Queue<IQueueItem> items)
        {
            try
            {
                var response = await BlobCache.LocalMachine.InsertObject(QString,JsonConvert.SerializeObject(items));
                return true;
            }
            catch (KeyNotFoundException)
            {
                return false;
            }
        }

    }
}

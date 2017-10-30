using System;
using Akavache;
using Hippo.Abstraction;


namespace Hippo.Implementation
{
    public static class HippoCurrent
    {
       
        public static void Init(string ApplicationName)
        {
            BlobCache.ApplicationName = ApplicationName;
        }

        private static StorageType storageType = StorageType.LocalMachine;
        public static StorageType StorageType 
        { 
            get { return storageType; }
            set 
            {
                storageType = value;
                BaseStorage.ChangeStorage();
            }
        } 

        public static StoreManager StoreManager { get; } = new StoreManager();

        internal static PendingQueue Queue { get; } = new PendingQueue();

        internal static Network Network { get; } = Queue;

    }
}

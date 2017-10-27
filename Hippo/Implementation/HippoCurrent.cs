using System;
using Akavache;
using Hippo.Abstraction;


namespace Hippo.Implementation
{
    public static class HippoCurrent
    {
       
        public static void Init()
        {
            BlobCache.ApplicationName = "ExperimentHippoing";
        }


        public static StoreManager StoreManager { get; } = new StoreManager();

        internal static PendingQueue Queue { get; } = new PendingQueue();

    }
}

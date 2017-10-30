using System;
using System.Threading.Tasks;

using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Hippo.Implementation;
using Hippo.Abstraction.Interfaces;

namespace Hippo.Abstraction
{

    internal class PendingQueue : Network, IPendingQueue
    {
        
        private Queue<object> PendingOperations = new Queue<object>();

        internal PendingQueue()
        {
            LoadQueueFromStorage();
        }

        public void Add<T>(QueueItem<T> item) where T : BaseTable
        {
            PendingOperations.Enqueue(item);
            QueueChanged();
            SaveQueueToStorage();
        }


        async Task DequeOperations()
        {
            ClearOutRedundantTask();

            var item = PendingOperations.First();

            // TODO
            await Task.Delay(1000);


            QueueChanged();
            SaveQueueToStorage();
        }


        public override void OnConnected()
        {
            base.OnConnected();
            //TODO
        }

        public override void OnDisconnected()
        {
            base.OnDisconnected();
            //TODO
        }

        void QueueChanged()
        {
            //TODO
        }

        public void ClearOutRedundantTask()
        {
            
        }

        private async void LoadQueueFromStorage()
        {
            var sq = await BaseStorage.GetQueue();

            if(sq!=null)
            {
                PendingOperations = sq;
            }
        }

        private async void SaveQueueToStorage()
        {
            await BaseStorage.SaveQueue(PendingOperations);
        }

    }
}

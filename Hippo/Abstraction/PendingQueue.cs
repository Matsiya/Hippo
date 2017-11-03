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
        
        private Queue<IQueueItem> PendingOperations = new Queue<IQueueItem>();

        internal PendingQueue()
        {
            LoadQueueFromStorage();

            if (IsOnline)
                OnConnected();
            else
                OnDisconnected();
        }

        public void Add<T>(QueueItem<T> item) where T : BaseTable
        {
            var cast_item = (IQueueItem)item;
            PendingOperations.Enqueue(cast_item);
            QueueChanged();
            SaveQueueToStorage();
        }


        public bool IsConflictWithQueue<T>(string id) where T : BaseTable
        {
            return PendingOperations.Where((arg) => arg.Type == typeof(T) && arg.Id == id).Any();
        }

        public bool IsConflictWithQueue<T>() where T : BaseTable
        {
            return PendingOperations.Where((arg) => arg.Type == typeof(T) ).Any();
        }

        async Task DequeOperations()
        {
            ClearOutRedundantTask();

            var item = PendingOperations.Peek();

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
            ClearOutRedundantTask();
        }

        private void ClearOutRedundantTask()
        {
            if (PendingOperations.Count <= 1)
                return;

            var item = PendingOperations.Peek();

            var similarItems = PendingOperations.Where( (arg) => arg.Type == item.Type);

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

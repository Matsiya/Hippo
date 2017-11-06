using System;
using System.Threading.Tasks;

using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Hippo.Implementation;
using Hippo.Abstraction.Interfaces;
using System.Reflection;

namespace Hippo.Abstraction
{

    internal class PendingQueue : Network, IPendingQueue
    {
        
        private List<IQueueItem> PendingOperations = new List<IQueueItem>();

        private bool IsRunning = false;

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
            PendingOperations.Add(cast_item);
            SaveQueueToStorage();
            QueueChanged();
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
            if (IsRunning)
                return;

            // TODO
            IsRunning = true;

            DequeOperations: if (IsOnline)
            {
                
                if (PendingOperations.Any())
                {                   
                    ClearOutRedundantTask();

                    var item = PendingOperations.First();

                    var store = HippoCurrent.StoreManager.GetStore(item.Type);

                    var st = await BaseStorage.GetItemAsync(item.Id);

                    if (item.OperationType == OperationType.Insert)
                    {
                       
                    }
                    else if (item.OperationType == OperationType.Remove)
                    {

                    }
                    else if (item.OperationType == OperationType.Update)
                    {

                    }
                                       

                    SaveQueueToStorage();

                    goto DequeOperations;
                }
            }

            IsRunning = false;
        }


        public override void OnConnected()
        {
            base.OnConnected();

            DequeOperations();
        }

        public override void OnDisconnected()
        {
            base.OnDisconnected();

            IsRunning = false;
        }


        void QueueChanged()
        {
            DequeOperations();
        }

        private void ClearOutRedundantTask()
        {
            if (PendingOperations.Count <= 1)
                return;

            //TODO

            var item = PendingOperations.First();

            var similarItems = PendingOperations.Where( (arg) => arg.Type == item.Type).ToList();

            if (similarItems.Any())
            {
                for (int i = 0; i < similarItems.Count-1; i++)
                {
                    PendingOperations.Remove(similarItems[i]);
                }
            }
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

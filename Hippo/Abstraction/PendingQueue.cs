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


        public void Add<T>(QueueItem<T> item) where T : BaseTable
        {
            PendingOperations.Enqueue(item);
            QueueChanged();
        }


        async Task DequeOperations()
        {
            ClearOutRedundantTask();

            var item = PendingOperations.First();

            await Task.Delay(1000);


            QueueChanged();
        }


        public override void OnConnected()
        {
            base.OnConnected();

        }

        public override void OnDisconnected()
        {
            base.OnDisconnected();
        }

        void QueueChanged()
        {
            
        }

        public void ClearOutRedundantTask()
        {
            
        }


    }
}

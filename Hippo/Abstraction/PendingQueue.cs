using System;
using Hippo.Abstraction.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Hippo.Abstraction
{
    public class PendingQueue 
    {
        
        private  Queue<object> PendingOperations = new Queue<object>();


        public void Add<T>(QueueItem<T> item) where T : BaseTable
        {
            PendingOperations.Enqueue(item);
        }

        void Operate()
        {
            
        }
    }
}

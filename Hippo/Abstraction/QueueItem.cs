using System;
using Hippo.Abstraction.Interfaces;


namespace Hippo.Abstraction
{
    public class QueueItem<T> : IQueueItem where T : BaseTable
    {                  
        public QueueItem(string id,OperationType type)
        {
            Id = id;
            OperationType = type;
            Type = typeof(T);
        }
    }
}

using System;

namespace Hippo.Abstraction
{
    public class QueueItem<T> where T : BaseTable
    {       

        public string Id { get; private set; }
        public OperationType Type { get; private set; }


        public QueueItem(string id,OperationType type)
        {
            Id = id;
            Type = type;
        }
    }

}

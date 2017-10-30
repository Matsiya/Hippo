using System;

namespace Hippo.Abstraction.Interfaces
{
    public class IQueueItem
    {
        public string Id { get; set; }
      
        public OperationType OperationType { get; set; }

        public Type Type { get; set; }
    }
}

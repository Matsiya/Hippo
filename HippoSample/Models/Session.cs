using System;
using Hippo.Abstraction;

namespace HippoSample.Models
{
    public class Session : BaseTable
    {        
    
        public Session()
        {            
        }

        public string Name { get; set; }

        public int Id { get; set; }

        public DateTime DateCreated { get; set; }
    
    }
}

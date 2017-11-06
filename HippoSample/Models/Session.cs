using System;
using Hippo.Abstraction;

namespace HippoSample.Models
{
    public class Session : BaseTable
    {        

        public string Name { get; set; }

        public string ID
        {
            get
            {
                return base.id;
            }
            set
            {
                base.id = value;
            }
        }

        public DateTime DateCreated { get; set; }
    
    }

    public class Tennis : BaseTable
    {

        public string NameOfSet { get; set; }

        public string ID
        {
            get
            {
                return base.id;
            }
            set
            {
                base.id = value;
            }
        }

    }

}

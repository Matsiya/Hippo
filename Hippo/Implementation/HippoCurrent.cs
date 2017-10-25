using System;
using Hippo.Abstraction;


namespace Hippo.Implementation
{
    public static class Hippo
    {
       
        public static void Init()
        {
              
        }


        public static StoreManager StoreManager { get; } = new StoreManager();


    }
}

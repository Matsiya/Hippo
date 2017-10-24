using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Reactive.Linq;
using Akavache;
using System.Collections;

namespace Hippo.Abstraction
{
    
    internal static class BaseStorage
    {           

        public static IBlobCache Storage = Akavache.BlobCache.LocalMachine;

    }
}

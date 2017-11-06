using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Hippo.Abstraction.Interfaces;
using Newtonsoft.Json;

namespace Hippo.Abstraction
{
    public class BaseTable : IBaseTable
    {
        [JsonIgnore]
        public string id { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName] string propertyname = null)
        {
            PropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propertyname));
        }

    }
}

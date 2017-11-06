using System;
using System.ComponentModel;

namespace Hippo.Abstraction.Interfaces
{
    public interface IBaseTable : INotifyPropertyChanged
    {
         string id { get; set; }
    }
}

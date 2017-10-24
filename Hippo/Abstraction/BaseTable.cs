using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Hippo.Abstraction.Interfaces;

namespace Hippo.Abstraction
{
    public class BaseTable : IBaseTable
    {

        public Action Method { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;


        protected void RaisePropertyChanged([CallerMemberName] string propertyname = null)
        {
            PropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propertyname));
        }

    }
}

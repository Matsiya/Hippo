using System;
using System.Threading.Tasks;
using Hippo.Abstraction;
using System.Collections.Generic;

namespace HippoSample.Services
{
    public interface IRestService<T> where T : BaseTable
    {

        Task<IEnumerable<T>> GetItemsAsync( );

        Task<T> GetItemAsync(string id );

        Task<T> InsertAsync(string id, T item );

        Task<bool> UpdateAsync(string id, T item );

        Task<bool> RemoveAsync(string id, T item );

       

    }
}

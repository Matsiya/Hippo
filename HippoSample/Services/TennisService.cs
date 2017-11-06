using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HippoSample.Models;

namespace HippoSample.Services
{
    public class TennisService : IRestService<Tennis>
    {
        public TennisService()
        {
        }

        public async Task<Tennis> GetItemAsync(string id)
        {
            await System.Threading.Tasks.Task.Delay(2000);

            return new Tennis() {  NameOfSet = "I am from server" };
        }

        public Task<IEnumerable<Tennis>> GetItemsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Tennis> InsertAsync(string id, Tennis item)
        {
            await System.Threading.Tasks.Task.Delay(2000);

            return item;
        }

        public Task<bool> RemoveAsync(string id, Tennis item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(string id, Tennis item)
        {
            throw new NotImplementedException();
        }
    }
}

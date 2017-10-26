using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HippoSample.Models;

namespace HippoSample.Services
{
    public class SessionService : IRestService<Session>
    {

        public const string Url = "http://www.api.net/matsiya/example"; 

        public SessionService()
        {
            
        }


        public async Task<Session> GetItemAsync(string id)
        {
            await System.Threading.Tasks.Task.Delay(2000);

            return new Session() { Name = "I am from server" };
        }

        public Task<IEnumerable<Session>> GetItemsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Session> InsertAsync(string id, Session item)
        {
            await System.Threading.Tasks.Task.Delay(2000);

            return item;
        }

        public Task<bool> RemoveAsync(string id, Session item)
        {
            throw new NotImplementedException();
        }

       
        public Task<bool> UpdateAsync(string id, Session item)
        {
            throw new NotImplementedException();
        }
    }
}

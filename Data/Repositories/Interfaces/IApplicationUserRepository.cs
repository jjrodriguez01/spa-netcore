using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace interrapidisimo.Data.Repositories.Interfaces
{
    public interface IApplicationUserRepository
    {
        Task<string?> GetUserId(string userName);
        
    }
}
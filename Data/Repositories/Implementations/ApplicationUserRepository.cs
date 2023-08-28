using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using interrapidisimo.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace interrapidisimo.Data.Repositories.Implementations
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly ApplicationDbContext _context;

        public ApplicationUserRepository(ApplicationDbContext context){
            this._context = context;
        }
        public async Task<string?> GetUserId(string userName)
        {
            var user = await _context.Users
                .Where(u => u.Email == userName)
                    .FirstOrDefaultAsync();
            return user?.Id;
        }
    }
}
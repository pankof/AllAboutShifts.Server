using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllAboutShifts.WebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace AllAboutShifts.WebApi.Account
{
    public class UserService : IUserService
    {
        private readonly ShiftsContext _dbContext;
        public UserService(ShiftsContext dbContext) => _dbContext = dbContext;

        public Task<User> Authenticate(string email, string password)
        {
            return _dbContext.Users.SingleOrDefaultAsync(x => x.Email == email && x.Password == password);
        }
    }
}

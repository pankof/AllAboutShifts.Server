using AllAboutShifts.WebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllAboutShifts.WebApi.Account
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllAboutShifts.WebApi.Entities
{
    public class ShiftsContext : DbContext
    {
        public ShiftsContext(DbContextOptions<ShiftsContext> options) : base(options)
        { }

        public DbSet<User> Users { get; set; }

    }
}

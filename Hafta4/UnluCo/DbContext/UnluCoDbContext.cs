using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCo.Core.Entities.User;

namespace UnluCo.DbContext
{
    public class UnluCoDbContext:IdentityDbContext<User>
    {
        public UnluCoDbContext(DbContextOptions<UnluCoDbContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}

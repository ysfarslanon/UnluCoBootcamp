using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCo.Entities;

namespace UnluCo.DataAccess
{
    public class UnluDbContext:DbContext
    {
        public UnluDbContext(DbContextOptions<UnluDbContext> options):base(options) 
        {

        }
        public DbSet<Plant> Plants { get; set; }
    }
}

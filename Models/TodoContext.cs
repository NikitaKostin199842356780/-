using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace thetasksApi.Models
{
   
        public class thetasksContext : DbContext
        {
            public thetasksContext(DbContextOptions<thetasksContext> options)
            : base(options)
            {
            }
            public DbSet<thetasksItem> thetasksItems { get; set; }
        }
    
}

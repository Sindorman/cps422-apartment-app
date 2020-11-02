using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace apartment_app.Data
{
    public class PropertiesContext : DbContext
    {
        public PropertiesContext (DbContextOptions<PropertiesContext> options)
            : base(options)
        {
        }

        public DbSet<apartment_app.Data.Property> Property { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Property>().ToTable("Properties");
        }
    }
}

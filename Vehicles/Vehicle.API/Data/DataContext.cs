using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicle.API.Data.Entities;

namespace Vehicle.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { 
        
        }

        public DbSet<Procedure> Procedure { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<VehicleType>().HasIndex(X => X.Description).IsUnique();
            modelBuilder.Entity<Procedure>().HasIndex(X => X.Description).IsUnique();
        }

    }
}

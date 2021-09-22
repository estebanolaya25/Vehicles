using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicle.API.Data.Entities;


namespace Vehicle.API.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { 
        
        }

        public DbSet<Brand> Brand { get; set; }
        public DbSet<Detail> details { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<History> histories { get; set; }
        public DbSet<Procedure> Procedure { get; set; }

        public DbSet<Vehicle.API.Data.Entities.Vehicle> Vehicles { get; set; }
        public DbSet<VehiclePhoto> vehiclePhotos { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Brand>().HasIndex(X => X.Description).IsUnique();
            modelBuilder.Entity<DocumentType>().HasIndex(X => X.Description).IsUnique();
            modelBuilder.Entity<Vehicle.API.Data.Entities.Vehicle>().HasIndex(X => X.Plaque).IsUnique();
            modelBuilder.Entity<VehicleType>().HasIndex(X => X.Description).IsUnique();
            modelBuilder.Entity<Procedure>().HasIndex(X => X.Description).IsUnique();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicle.API.Data.Entities;

namespace Vehicle.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckVehicleTypeAsync();
            await CheckProcedureAsync();
            await CheckDocumentType();
            await CheckBrand();
        
        }

        private async Task CheckVehicleTypeAsync()
        {
            if (!_context.VehicleTypes.Any())
            {
                _context.VehicleTypes.Add(new VehicleType { Description = "Carro" });
                _context.VehicleTypes.Add(new VehicleType { Description = "Motocicleta" });
                await _context.SaveChangesAsync();

            }
        }

        private async Task CheckProcedureAsync()
        {
            if (!_context.Procedure.Any())
            {
                _context.Procedure.Add(new Procedure { Description = "Cambio aceite", Price=30000 });
                _context.Procedure.Add(new Procedure { Description = "Balanceo", Price=40000 });
                await _context.SaveChangesAsync();

            }
        }
        private async Task CheckDocumentType()
        {
            if (!_context.DocumentTypes.Any())
            {
                _context.DocumentTypes.Add(new DocumentType { Description = "Cedula" });
                _context.DocumentTypes.Add(new DocumentType { Description = "Nit" });
                await _context.SaveChangesAsync();

            }
        }
        private async Task CheckBrand()
        {
            if (!_context.Brand.Any())
            {
                _context.Brand.Add(new Brand { Description = "YAMAHA" });
                _context.Brand.Add(new Brand { Description = "SUZUKI" });
                await _context.SaveChangesAsync();

            }
        }


    }
}

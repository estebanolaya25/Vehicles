using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicle.API.Data.Entities;
using Vehicle.API.Helpers;
using Vehicles.Common.Enums;

namespace Vehicle.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckVehicleTypeAsync();
            await CheckProcedureAsync();
            await CheckDocumentType();
            await CheckBrand();
            await CheckRolesAsycn();
            await CheckUserAsync("123", "juan","olaya","estebanolaya25@yopmail.com", "3104433819","calle 105a 8134", UserType.Admin);
            await CheckUserAsync("001", "juan", "olaya", "001@yopmail.com", "3104433819", "calle 105a 8134", UserType.User);
            await CheckUserAsync("002", "juan", "olaya", "002@yopmail.com", "3104433819", "calle 105a 8134", UserType.User);
            await CheckUserAsync("003", "juan", "olaya", "003@yopmail.com", "3104433819", "calle 105a 8134", UserType.User);

        }

        private  async Task CheckUserAsync(string documento, string fistName, string lastName, string email, string phoneNumber, string address, UserType userType)
        {
            User user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new User
                {
                    Address = address,
                    Document = documento,
                    DocumentType = _context.DocumentTypes.FirstOrDefault(x => x.Description == "Cedula"),
                    Email = email,
                    FirstName = fistName,
                    LastName = lastName,
                    PhoneNumber = phoneNumber,
                    UserName = email,
                    UserType = userType
                };
                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }
        }

        private async Task CheckRolesAsycn()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());

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

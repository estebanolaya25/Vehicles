using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicle.API.Data.Entities;
using Vehicle.API.Models;

namespace Vehicle.API.Helpers
{
    public interface IConverterHelper
    {
        Task<User> ToUserAsync(UserViewModel model, Guid imageId, bool isNew);

        UserViewModel ToUserViewModel(User user);

        Task<Vehicle.API.Data.Entities.Vehicle> ToVehicleAsync(VehicleViewModel model, bool isNew);

        VehicleViewModel ToVehicleViewModel(Vehicle.API.Data.Entities.Vehicle vehicle);

       // Task<Detail> ToDetailAsync(DetailViewModel model, bool isNew);

       // DetailViewModel ToDetailViewModel(Detail detail);
    }
}

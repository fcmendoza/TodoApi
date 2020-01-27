using System.Collections.Generic;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    public interface IVehicleRepository {
        ICollection<Vehicle> GetVehicles(VehicleSearchOptions options);
        Vehicle GetVehicle(string vin);
    }

    public class VehicleSearchOptions {
        public bool HasDelivery { get; set; }
        public int MinRating { get; set; }
        public Color Color { get; set; }
        // and much much more.
    }

    public class VehicleRepository : IVehicleRepository
    {
        public ICollection<Vehicle> GetVehicles(VehicleSearchOptions options)
        {
            throw new System.NotImplementedException();
        }

        public Vehicle GetVehicle(string vin)
        {
            // TODO: Get the vehicle from cache or form the data store.
            return new Vehicle { 
                VIN = vin, 
                Make = "Tesla"
            };
        }
    }
}
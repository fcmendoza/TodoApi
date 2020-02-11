using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    public interface IVehicleRepository {
        ICollection<Vehicle> GetVehicles(VehicleSearchOptions options);
        Vehicle GetVehicle(string vin);
        Task<Vehicle> GetVehicleAsync(string vin);
        Task<SuggestedPrice> GetSuggestedPriceAsync(string vin);
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

        public async Task<Vehicle> GetVehicleAsync(string vin) {
            await Task.Delay(2000); // simulates the time it takes calling another service (or execute a database call/query) that returns vehicle data by vin.
            return new Vehicle {
                VIN = vin,
                Make = "Tesla",
                Model = "Model X"
            };
        }

        public async Task<SuggestedPrice> GetSuggestedPriceAsync(string vin) {
            await Task.Delay(2000); // simulates the time it takes calling another service (or execute a database call/query) that returns the price based on the vin.
            return new SuggestedPrice {
                Make = "Tesla",
                Model = "Model X",
                Price = 149.50m
            };
        }
    }
}

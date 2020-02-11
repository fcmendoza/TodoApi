using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase {
        IVehicleRepository _repo;
        public VehicleController(IVehicleRepository vehicleRepository) {
            _repo = vehicleRepository;
        }

        // GET: api/Vehicle/abc123
        [HttpGet("{vin}")]
        public Vehicle Get(string vin) {
            return _repo.GetVehicle(vin);
        }

        [HttpGet("Price/{vin}")]
        public async Task<ActionResult<VehicleData>> GetVehiclePriceAsync(string vin) {
            var vehicle = _repo.GetVehicleAsync(vin);
            var price = _repo.GetSuggestedPriceAsync(vin);

            var data = new VehicleData {
                Vehicle = await vehicle,
                Price = await price
            };

            //return Ok(data);
            return data;
        }
    }

    public class VehicleData {
        public Vehicle Vehicle { get; set; }
        public SuggestedPrice Price { get; set; }
    }
}

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
    }
}

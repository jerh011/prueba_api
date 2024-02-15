using Microsoft.AspNetCore.Mvc;
using API_JERH.Services;
using API_JERH.Models;

namespace API_JERH.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriversControllers : ControllerBase
    {
        private readonly ILogger<DriversControllers> _logger;
        private readonly DriverServices _driversServices;

        public DriversControllers(ILogger<DriversControllers> logger, DriverServices driverServices)
        {
            _logger = logger;
            _driversServices = driverServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetDrivers()
        {
            var drivers = await _driversServices.GetAsync();
            return Ok(drivers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDriversByID(string Id)
        {

            return Ok(await _driversServices.GetDriverById(Id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateDriver([FromBody] Driver drive)
        {
            if (drive == null)
                return BadRequest();
            if (drive.Name == string.Empty)
                ModelState.AddModelError("Name", "El driver no debe estar vacio");

            await _driversServices.InsertDriver(drive);
            return Created("Created", true);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDriver([FromBody] Driver drive, string id)
        {
            if (drive == null)
                return BadRequest();
            if (drive.Name == string.Empty)
                ModelState.AddModelError("Name", "El driver no debe estar vacio");

            drive.Id = id;

            await _driversServices.UpdateDriver(drive);
            return Created("Created", true);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletedriver(string Id)
        {

            await _driversServices.DelateDriver(Id);
            return NoContent();
        }


    }
}
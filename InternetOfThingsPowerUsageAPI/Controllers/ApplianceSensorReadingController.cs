using InternetOfThingsPowerUsageAPI.Models.Data;
using InternetOfThingsPowerUsageAPI.Models.Data.Repositories;
using InternetOfThingsPowerUsageAPI.Models.Local;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InternetOfThingsPowerUsageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplianceSensorReadingController : MainController<ApplianceSensorReading, int>
    {
        private readonly ApplicationDbContext _context;
        public ApplianceSensorReadingController(ApplicationDbContext context) : base(context) => _context = context;

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("household/{id}")]
        public IActionResult GetByHouseHoldId([FromRoute] int id, [FromQuery] Pagination pagination)
        {
            var data = new ApplianceSensorReadingRepository(_context).FindByHouseHoldId(id);
            if (data == null) return StatusCode(StatusCodes.Status404NotFound, "Not Found");
            return Ok(data);
        }
    }
}

using InternetOfThingsPowerUsageAPI.Models.Data;
using InternetOfThingsPowerUsageAPI.Models.Data.Repositories;
using InternetOfThingsPowerUsageAPI.Models.Local;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InternetOfThingsPowerUsageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppliancePatternController : MainController<AppliancePattern, int>
    {
        private readonly ApplicationDbContext _context;
        public AppliancePatternController(ApplicationDbContext context) : base(context) => _context = context;
      
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("household/{id}")]
        public IActionResult GetByHouseHoldId([FromRoute] int id)
        {
            var data = new AppliancePatternRepository(_context).FindByHouseHoldId(id);
            if (data == null) return StatusCode(StatusCodes.Status404NotFound, "Not Found");
            return Ok(data);
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("appliance/{id}")]
        public IActionResult GetByApplianceId([FromRoute] int id)
        {
            var data = new AppliancePatternRepository(_context).FindByApplianceId(id);
            if (data == null) return StatusCode(StatusCodes.Status404NotFound, "Not Found");
            return Ok(data);
        }
    }
}

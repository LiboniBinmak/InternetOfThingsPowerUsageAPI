using InternetOfThingsPowerUsageAPI.Models.Data;
using InternetOfThingsPowerUsageAPI.Models.Data.Repositories;
using InternetOfThingsPowerUsageAPI.Models.Local;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace InternetOfThingsPowerUsageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplianceController : MainController<Appliance, int>
    {
        private readonly ApplicationDbContext _context;
        public ApplianceController(ApplicationDbContext context) : base(context) => _context = context;

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{isBeingConfigured}/{houseHoldId}")]
        public IActionResult ConfigureHouseHold([FromRoute] bool isBeingConfigured, [FromRoute] int houseHoldId)
        {
            var data = new ApplianceRepository(_context).FindByIsBeingConfiguredAndHouseHold(isBeingConfigured,houseHoldId);
            if (data == null) return StatusCode(StatusCodes.Status404NotFound, "Not Found");
            return Ok(data);
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("ActivateisBeingConfigured/{id}")]
        public IActionResult ActivateApplianceByHouseHold([FromRoute] int id)
        {
            var applianceRepository = new ApplianceRepository(_context);
            var data = applianceRepository.Find(id);
            if (data == null) return StatusCode(StatusCodes.Status404NotFound, "Not Found");
            var appliances = applianceRepository.FindByHouseHoldId(data.HouseHoldId).ToList();
            foreach (var appliance in appliances)
            {
                appliance.IsBeingConfigured = false;
                if (appliance.Id == id)
                    appliance.IsBeingConfigured = !appliance.IsBeingConfigured;
                new ApplianceRepository(_context).Update(appliance.Id,appliance);
            }
            return Ok(applianceRepository.Find(id));
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("household/{id}")]
        public IActionResult GetByHouseHoldId([FromRoute]int id,[FromQuery] Pagination pagination)
        {
            var data = new ApplianceRepository(_context).FindByHouseHoldId(id);
            if (data == null) return StatusCode(StatusCodes.Status404NotFound, "Not Found");
            return Ok(data);
        }
    }
}

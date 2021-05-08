using InternetOfThingsPowerUsageAPI.Models.Data;
using InternetOfThingsPowerUsageAPI.Models.Data.Repositories;
using InternetOfThingsPowerUsageAPI.Models.Local;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InternetOfThingsPowerUsageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseHoldUserController : MainController<HouseHoldUser, int>
    {
        private readonly ApplicationDbContext _context;
        public HouseHoldUserController(ApplicationDbContext context) : base(context) => _context = context;

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("user/{id}")]
        public IActionResult GetByUserId([FromRoute] string id, [FromQuery] Pagination pagination)
        {
            var data = new HouseHoldUserRepository(_context).FindByUserId(id);
            if (data == null) return StatusCode(StatusCodes.Status404NotFound, "Not Found");
            return Ok(data);
        }       
    }
}

using InternetOfThingsPowerUsageAPI.Models.Data;
using InternetOfThingsPowerUsageAPI.Models.Data.Repositories;
using InternetOfThingsPowerUsageAPI.Models.Local;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace InternetOfThingsPowerUsageAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController<T, Tkey> : ControllerBase where T : class
                                                             where Tkey : struct
    {
        private readonly ApplicationDbContext _context;
        public MainController(ApplicationDbContext context) => _context = context;

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public IActionResult Get([FromQuery] Pagination pagination)
        {
            var data = new MainRepository<T>(_context).Find().Skip(pagination.Page * pagination.Size).Take(pagination.Size);
            if (data == null) return StatusCode(StatusCodes.Status404NotFound, "Not Found");
            return Ok(data);
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public virtual IActionResult Get([FromRoute] Tkey id)
        {
            var data = new MainRepository<T>(_context).Find(id);
            if (data == null) return StatusCode(StatusCodes.Status404NotFound, "Not Found");
            return Ok(data);
        }

        [ProducesResponseType(typeof(Exception), StatusCodes.Status403Forbidden)]
        [HttpPost]
        public virtual IActionResult Post([FromBody] T value)
        {
            try
            {
                return Ok(new Result<T>(true, "Saved successfully", new MainRepository<T>(_context).Add(value)));
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status403Forbidden, exception);
            }
        }

        [ProducesResponseType(typeof(Exception), StatusCodes.Status403Forbidden)]
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] Tkey id)
        {
            try
            {
                new MainRepository<T>(_context).Delete(id);
                return Ok(new Result<T>(true, "Deleted successfully"));
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status403Forbidden, exception);
            }
        }

        [ProducesResponseType(typeof(Exception), StatusCodes.Status403Forbidden)]
        [HttpPut("{id}")]
        public virtual IActionResult Put([FromRoute] Tkey id, [FromBody] T value)
        {
            try
            {
                return Ok(new Result<T>(true, "Updated successfully", new MainRepository<T>(_context).Update(id, value)));
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status403Forbidden, exception);
            }
        }
    }
}

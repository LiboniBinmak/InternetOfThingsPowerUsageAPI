using InternetOfThingsPowerUsageAPI.Models.Data;
using Microsoft.AspNetCore.Mvc;

namespace InternetOfThingsPowerUsageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorReadingController : MainController<SensorReading, int>
    {
        public SensorReadingController(ApplicationDbContext context) : base(context)
        {
        }
    }
}

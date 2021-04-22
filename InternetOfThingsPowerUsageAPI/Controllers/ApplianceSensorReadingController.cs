using InternetOfThingsPowerUsageAPI.Models.Data;
using Microsoft.AspNetCore.Mvc;

namespace InternetOfThingsPowerUsageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplianceSensorReadingController : MainController<ApplianceSensorReading, int>
    {
        public ApplianceSensorReadingController(ApplicationDbContext context) : base(context)
        {
        }
    }
}

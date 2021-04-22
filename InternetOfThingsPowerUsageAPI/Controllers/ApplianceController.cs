using InternetOfThingsPowerUsageAPI.Models.Data;
using Microsoft.AspNetCore.Mvc;

namespace InternetOfThingsPowerUsageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplianceController : MainController<Appliance, int>
    {
        public ApplianceController(ApplicationDbContext context) : base(context)
        {
        }
    }
}

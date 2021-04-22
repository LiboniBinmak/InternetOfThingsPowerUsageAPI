using InternetOfThingsPowerUsageAPI.Models.Data;
using Microsoft.AspNetCore.Mvc;

namespace InternetOfThingsPowerUsageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppliancePatternController : MainController<AppliancePattern, int>
    {
        public AppliancePatternController(ApplicationDbContext context) : base(context)
        {
        }
    }
}

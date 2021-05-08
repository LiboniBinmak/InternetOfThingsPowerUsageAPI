using InternetOfThingsPowerUsageAPI.Models.Data;
using Microsoft.AspNetCore.Mvc;

namespace InternetOfThingsPowerUsageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseHoldController : MainController<HouseHold, int>
    {
        public HouseHoldController(ApplicationDbContext context) : base(context)
        {
        }
    }
}

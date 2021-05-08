using InternetOfThingsPowerUsageAPI.Models.Data;
using Microsoft.AspNetCore.Mvc;

namespace InternetOfThingsPowerUsageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TownController : MainController<Town, int>
    {
        public TownController(ApplicationDbContext context) : base(context)
        {
        }
    }
}

using InternetOfThingsPowerUsageAPI.Models.Data;
using Microsoft.AspNetCore.Mvc;

namespace InternetOfThingsPowerUsageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : MainController<Status, int>
    {
        public StatusController(ApplicationDbContext context) : base(context)
        {
        }
    }
}

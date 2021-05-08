using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace InternetOfThingsPowerUsageAPI.Models.Data.Repositories
{
    public class ApplianceSensorReadingRepository : MainRepository<ApplianceSensorReading>
    {

        private readonly ApplicationDbContext _context;
        public ApplianceSensorReadingRepository(ApplicationDbContext context) : base(context) => _context = context;
        public IEnumerable<ApplianceSensorReading> FindByHouseHoldId(int houseHoldId) => _context.ApplianceSensorReadings.Include(a => a.Appliance).ThenInclude(a => a.HouseHold).Where(a => a.Appliance.HouseHoldId == houseHoldId);

    }
}

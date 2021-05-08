using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace InternetOfThingsPowerUsageAPI.Models.Data.Repositories
{
    public class AppliancePatternRepository : MainRepository<AppliancePattern>
    {
        private readonly ApplicationDbContext _context;
        public AppliancePatternRepository(ApplicationDbContext context) : base(context) => _context = context;

        public IEnumerable<AppliancePattern> FindByHouseHoldId(int houseHoldId) => _context.AppliancePatterns.Include(a => a.Appliance).ThenInclude(a=>a.HouseHold).Where(a => a.Appliance.HouseHoldId == houseHoldId);
        public IEnumerable<AppliancePattern> FindByApplianceId(int applianceId) => _context.AppliancePatterns.Include(a => a.Appliance).ThenInclude(a=>a.HouseHold).Where(a => a.ApplianceId == applianceId);


    }
}

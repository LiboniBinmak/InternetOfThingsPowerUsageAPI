using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace InternetOfThingsPowerUsageAPI.Models.Data.Repositories
{
    public class ApplianceRepository : MainRepository<Appliance>
    {
        private readonly ApplicationDbContext _context;
        public ApplianceRepository(ApplicationDbContext context) : base(context) => _context = context;

        public Appliance FindByIsBeingConfiguredAndHouseHold(bool isBeingConfigured, int houseHoldId) => _context.Appliances.FirstOrDefault(a => a.IsBeingConfigured == isBeingConfigured && a.HouseHoldId == houseHoldId);
        public IEnumerable<Appliance> FindByHouseHoldId(int houseHoldId) => _context.Appliances.Where(a => a.HouseHoldId == houseHoldId).Include(a=>a.HouseHold);

    }
}

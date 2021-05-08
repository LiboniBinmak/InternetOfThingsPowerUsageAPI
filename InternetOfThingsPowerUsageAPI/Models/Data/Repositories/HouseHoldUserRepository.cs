using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace InternetOfThingsPowerUsageAPI.Models.Data.Repositories
{
    public class HouseHoldUserRepository : MainRepository<HouseHoldUser>
    {
        private readonly ApplicationDbContext _context;
        public HouseHoldUserRepository(ApplicationDbContext context) : base(context) => _context = context;

        public IEnumerable<HouseHoldUser> FindByUserId(string userId) => _context.HouseHoldUsers.Include(a => a.HouseHold).Where(a => a.UserId == userId);


    }
}

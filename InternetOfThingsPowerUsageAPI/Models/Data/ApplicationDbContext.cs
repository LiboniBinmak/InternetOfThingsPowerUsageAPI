using Microsoft.EntityFrameworkCore;

namespace InternetOfThingsPowerUsageAPI.Models.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Appliance> Appliances { get; set; }
        public DbSet<AppliancePattern> AppliancePatterns { get; set; }
        public DbSet<ApplianceSensorReading> ApplianceSensorReadings { get; set; }
        public DbSet<SensorReading> SensorReadings { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<HouseHold> HouseHolds { get; set; }
        public DbSet<HouseHoldUser> HouseHoldUsers { get; set; }
    }
}

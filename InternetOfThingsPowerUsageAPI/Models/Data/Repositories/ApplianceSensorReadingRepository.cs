namespace InternetOfThingsPowerUsageAPI.Models.Data.Repositories
{
    public class ApplianceSensorReadingRepository : MainRepository<ApplianceSensorReading>
    {
        public ApplianceSensorReadingRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

namespace InternetOfThingsPowerUsageAPI.Models.Data.Repositories
{
    public class SensorReadingRepository : MainRepository<SensorReading>
    {
        public SensorReadingRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

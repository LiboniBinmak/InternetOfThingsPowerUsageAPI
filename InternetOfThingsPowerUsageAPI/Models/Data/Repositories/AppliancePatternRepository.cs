namespace InternetOfThingsPowerUsageAPI.Models.Data.Repositories
{
    public class AppliancePatternRepository : MainRepository<AppliancePattern>
    {
        public AppliancePatternRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

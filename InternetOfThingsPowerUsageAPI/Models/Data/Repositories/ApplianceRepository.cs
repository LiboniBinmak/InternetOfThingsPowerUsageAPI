namespace InternetOfThingsPowerUsageAPI.Models.Data.Repositories
{
    public class ApplianceRepository : MainRepository<Appliance>
    {
        public ApplianceRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

namespace InternetOfThingsPowerUsageAPI.Models.Data.Repositories
{
    public class TownRepository : MainRepository<Town>
    {
        public TownRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

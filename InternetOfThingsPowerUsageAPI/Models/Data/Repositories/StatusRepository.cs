namespace InternetOfThingsPowerUsageAPI.Models.Data.Repositories
{
    public class StatusRepository : MainRepository<Status>
    {
        public StatusRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

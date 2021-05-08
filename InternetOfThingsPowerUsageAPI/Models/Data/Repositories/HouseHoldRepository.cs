namespace InternetOfThingsPowerUsageAPI.Models.Data.Repositories
{
    public class HouseHoldRepository : MainRepository<HouseHold>
    {
        public HouseHoldRepository(ApplicationDbContext context) : base(context)
        {
        }

       
    }
}

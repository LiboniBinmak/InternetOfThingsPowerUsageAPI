namespace InternetOfThingsPowerUsageAPI.Models.Data
{
    public class HouseHoldUser
    {
        public int Id { get; set; }
        public int HouseHoldId { get; set; }
        public string UserId { get; set; }
        public virtual HouseHold HouseHold { get; set; }
    }
}

namespace InternetOfThingsPowerUsageAPI.Models.Local
{
    public class Value
    {
        public decimal Current { get; set; }
        public decimal Voltage { get; set; }
        public decimal FormFactor { get; set; }
        public int HouseHoldId { get; set; }
    }
}

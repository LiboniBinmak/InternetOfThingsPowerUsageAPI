using System;
namespace InternetOfThingsPowerUsageAPI.Models.Data
{
    public class SensorReading
    {
        public int Id { get; set; }
        public decimal Current { get; set; }
        public decimal ReactivePower { get; set; }
        public decimal RealPower { get; set; }
        public DateTime DateCreated { get; set; }
    }
}

using System;
namespace InternetOfThingsPowerUsageAPI.Models.Data
{
    public class SensorReading
    {
        public int Id { get; set; }
        public decimal Current { get; set; }
        public decimal Power { get; set; }
        public decimal FormFactor { get; set; }
        public DateTime DateCreated { get; set; }
    }
}

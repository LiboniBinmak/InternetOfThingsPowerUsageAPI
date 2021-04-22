﻿namespace InternetOfThingsPowerUsageAPI.Models.Data
{
    public class ApplianceSensorReading
    {
        public int Id { get; set; }
        public int ApplianceId { get; set; }
        public int SensorReadingId { get; set; }
        public decimal Current { get; set; }
        public decimal ReactivePower { get; set; }
        public decimal RealPower { get; set; }
        public virtual SensorReading SensorReading { get; set; }
        public virtual Appliance Appliance { get; set; }
    }
}

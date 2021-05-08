using System;

namespace InternetOfThingsPowerUsageAPI.Models.Data
{
    public class AppliancePattern
    {
        public int Id { get; set; }
        public int ApplianceId { get; set; }
        public decimal Current { get; set; }
        public decimal Power { get; set; }
        public decimal FormFactor { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual Appliance Appliance { get; set; }
    }
}

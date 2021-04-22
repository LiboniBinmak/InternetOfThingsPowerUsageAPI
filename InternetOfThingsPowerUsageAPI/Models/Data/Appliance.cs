using System;

namespace InternetOfThingsPowerUsageAPI.Models.Data
{
    public class Appliance
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal PowerRating { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}

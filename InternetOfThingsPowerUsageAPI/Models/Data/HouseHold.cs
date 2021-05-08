
using System;

namespace InternetOfThingsPowerUsageAPI.Models.Data
{
    public class HouseHold
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int TownId { get; set; }
        public DateTime DateTime { get; set; }

        public virtual Town Town { get; set; }

    }
}

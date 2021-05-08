using InternetOfThingsPowerUsageAPI.Enums;
using InternetOfThingsPowerUsageAPI.Models.Data;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace InternetOfThingsPowerUsageAPI.Models.Local
{
    public class BroadcastHub : Hub
    {
        public string GetConnectionId() => Context.ConnectionId;

        public async Task SendCurrentPower(decimal power)
        {
            await Clients.All.SendAsync(BroadcastHubMethod.CurrentPower.GetEnumDescription(), power);
        }

        public async Task SendAppliancePower(ApplianceHub appliance)
        {
            await Clients.All.SendAsync(BroadcastHubMethod.AppliancePower.GetEnumDescription(), appliance);
        }

        public async Task SendAppliancePattern(AppliancePattern appliance)
        {
            await Clients.All.SendAsync(BroadcastHubMethod.AppliancePattern.GetEnumDescription(), appliance);
        }
    }
}

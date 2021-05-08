using System.Threading.Tasks;

namespace InternetOfThingsPowerUsageAPI.Models.Local
{
    public interface IHubClient
    {
        Task BroadcastMessage();
    }
}

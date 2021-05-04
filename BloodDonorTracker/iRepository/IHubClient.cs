using System.Threading.Tasks;

namespace BloodDonorTracker.iRepository
{
    public interface IHubClient
    {
        Task BroadcastMessage();
    }
}
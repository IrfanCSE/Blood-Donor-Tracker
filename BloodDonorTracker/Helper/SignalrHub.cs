using BloodDonorTracker.iRepository;
using Microsoft.AspNetCore.SignalR;

namespace BloodDonorTracker.Helper
{
    public class SignalrHub : Hub<IHubClient>
    {

    }
}
using System.Threading.Tasks;
namespace ecoupon.api.Hub
{
    public interface IHubClient
    {
        Task BroadcastMessage();
    }
}
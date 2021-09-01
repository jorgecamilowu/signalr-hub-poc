using System.Threading.Tasks;
using SignalRServer.Models;

namespace SignalRServer.Hubs.Clients
{
    public interface ISalesClient
    {
        Task ReceiveNotification(Notification notification);
        Task ReceiveBroadcast(Message message);
    }
}

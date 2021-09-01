using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SignalRServer.Hubs.Clients;
using SignalRServer.Models;

namespace SignalRServer.Hubs
{
    public class NotificationHub : Hub<ISalesClient>
    {
        // Method activated by the client
        public async Task Broadcast(Message message)
        {
            Console.WriteLine("===================================");
            Console.WriteLine("Broadcasting message");
            Console.WriteLine($"From: {message.Sender}");
            Console.WriteLine($"Type: {message.Type}");
            Console.WriteLine($"Content: {message.Content}");
            await Clients.All.ReceiveBroadcast(message);
        }

        // Connection state listeners
        public override Task OnConnectedAsync()
        {
            Console.WriteLine("Client connected");
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            Console.WriteLine("Client disconnected");
            return base.OnDisconnectedAsync(exception);
        }
    }
}

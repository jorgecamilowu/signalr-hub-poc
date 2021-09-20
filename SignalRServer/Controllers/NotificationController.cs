using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRServer.Hubs;
using SignalRServer.Hubs.Clients;
using SignalRServer.Models;

namespace SignalRServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly IHubContext<NotificationHub, ISalesClient> _hubContext;

        public NotificationController(IHubContext<NotificationHub, ISalesClient> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost]
        [Route("Subscriptions")]
        public async Task SubscribePaymentStatus(string id)
        {
            await _hubContext.Clients.Client(id).ReceiveNotification(new Notification
            {

                Code = "PaymentStatus",
                Description = "Payment Accepted"
            });

            Thread.Sleep(500);

            await _hubContext.Clients.Client(id).ReceiveNotification(new Notification
            {
                Code = "PaymentStatus",
                Description = "Processing payment"
            });

            Thread.Sleep(2000);

            await _hubContext.Clients.Client(id).ReceiveNotification(new Notification
            {
                Code = "PaymentStatus",
                Description = "Payment Success"
            });

        }

        [HttpPost]
        public async Task SendNotification(string id, string code, string description)
        {
            await _hubContext.Clients.Client(id).ReceiveNotification(new Notification
            {
                Code = code,
                Description = description
            });
        }
    }
}

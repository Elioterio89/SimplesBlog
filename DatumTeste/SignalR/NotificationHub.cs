using Microsoft.AspNetCore.SignalR;

namespace BlogDatum.SignalR
{
    public class NotificationHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            Console.WriteLine("Client connected: " + Context.ConnectionId);
            await base.OnConnectedAsync();
        }


        public async Task SendNotification(string message)
        {
            Console.WriteLine($"Sending notification: {message}");
            await Clients.All.SendAsync("ReceiveNotification", message);
        }
    }
}

using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Orderhub
{
    public class HubClass : Hub // ✅ Renamed class to match your file `hub.cs`
    {
        public async Task NotifyAdmin(string message)
        {
            await Clients.All.SendAsync("ReceiveNotification", message);
        }

        public async Task UpdateOrderCount(int orderCount)
        {
            await Clients.All.SendAsync("UpdateOrderCount", orderCount); // Update the order count in admin page
        }

        public async Task SendOrder(Order order)
        {
            await Clients.All.SendAsync("ReceiveOrder", order); // ✅ Ensure correct method name
        }

        public class Order
        {
            public string CustomerName { get; set; } = "";
            public string ItemName { get; set; } = "";
            public int Quantity { get; set; }
        }
    }
}
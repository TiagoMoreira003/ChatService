using Microsoft.AspNetCore.SignalR;

namespace Server1.Controllers
{
	public class ChatHub : Hub
	{
		public async Task SendMessage(Guid user, string message)
		{
			await Clients.All.SendAsync("ReceiveMessage", user, message);
		}
	}
}
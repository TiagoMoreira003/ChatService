namespace Server.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.SignalR;

	[Controller]
	public class ChatHub : Hub
	{
		[Route("SendMessage")]
		public async Task SendMessage(Guid user, string message)
			=> await Clients.All.SendAsync("ReceiveMessage", user, message);
	}
}
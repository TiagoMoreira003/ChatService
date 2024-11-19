using Client1;
using Microsoft.AspNetCore.SignalR.Client;

public class Program
{
	private readonly HubConnection connection;

	public static async Task Main(string[] agrs)
	{
		HubConnection connection = new HubConnectionBuilder()
			.WithUrl("http://localhost:5262/Chat")
			.Build();

		connection.On<Guid, string>("ReceiveMessage", (user, message) =>
		{
			Console.WriteLine($"User {user}: {message}");
		});

		Client client = new Client();
		Guid Id = client.Id;

		await connection.StartAsync();
		Console.WriteLine("Connected to the hub!");

		Console.WriteLine("Do you want to send messages(1/0): ");
		string option = Console.ReadLine();

		while (option == "1")
		{
			Console.WriteLine("Send message to all clients connected: ");
			var message = Console.ReadLine();

			await SendMessage(connection, Id, message);

			Console.WriteLine("Message sent!");

			Console.WriteLine("Do you want to send more messages(1/0): ");
			option = Console.ReadLine();

			if (option == "0")
			{
				Console.WriteLine("Goodbye!");
			}
		}
	}

	public static async Task SendMessage(HubConnection connection, Guid userId, string text)
	{
		try
		{
			await connection.InvokeAsync("SendMessage", userId, text);
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Error sending message: {ex.Message}");
		}
	}
}
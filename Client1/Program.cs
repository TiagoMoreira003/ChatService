using Client1;
using Microsoft.AspNetCore.SignalR.Client;
using System.Text;
using System.Text.Json;

public class Program
{
	private static HttpClient client = new HttpClient();
	private readonly HubConnection connection;

	public static async Task Main(string[] agrs)
	{
		// Config connection
		HubConnection connection = new HubConnectionBuilder()
			.WithUrl("http://localhost:5262/Chat")
			.Build();
		// Response to the event ReceiveMessage
		connection.On<Guid, string, DateTime>("ReceiveMessage", (username, message, date) =>
			Console.WriteLine($"{username}: {message} ----- {date}"));

		Console.WriteLine("Do you have an account?(y/n)");
		string option = Console.ReadLine();

		if (option == "y")
		{
			Console.WriteLine("Username: ");
			string username = Console.ReadLine();

			Console.WriteLine("Password: ");
			string password = Console.ReadLine();

			Console.WriteLine("Press enter to continue");

			Console.ReadLine();

			Console.Clear();

			// Fazer pedido ao BE para verificar se o user existe
			await LoginAsync(username, password);
		}

		Client client = new Client();
		Guid Id = client.Id;

		await connection.StartAsync();
		Console.WriteLine("Connected to the hub!");

		Console.WriteLine("Do you want to send messages(1/0): ");
		string option2 = Console.ReadLine();

		while (option2 == "1")
		{
			Console.WriteLine("Send message to all clients connected: ");
			var text = Console.ReadLine();

			Message message = new Message(text, Id);

			await SendMessage(connection, message.Id, message.Text, message.Time);

			Console.WriteLine("Message sent!");

			Console.WriteLine("Do you want to send more messages(1/0): ");
			option2 = Console.ReadLine();

			if (option2 == "0")
			{
				Console.WriteLine("Goodbye!");
			}
		}
	}

	public static async Task SendMessage(HubConnection connection, Guid userId, string text, DateTime dateTime)
	{
		try
		{
			await connection.InvokeAsync("SendMessage", userId, text, dateTime);
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Error sending message: {ex.Message}");
		}
	}

	private static async Task LoginAsync(string username, string password)
	{
		string url = $"http://localhost:7088/User/{username}&{password}";

		using (HttpClient client = new HttpClient())
		{
		}
	}

	private static async Task Register(string username, string password)
	{
		string url = "http://localhost:7088/User";

		var loginData = new
		{
			Username = username,
			Password = password
		};

		string jsonData = JsonSerializer.Serialize(loginData);

		using (HttpClient client = new HttpClient())
		{
			var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

			HttpResponseMessage response = await client.PostAsync(url, content);

			if (response.IsSuccessStatusCode)
			{
				string responseBody = await response.Content.ReadAsStringAsync();
				Console.WriteLine("Login Successful!");
				Console.WriteLine("Response: " + responseBody);
			}
			else
			{
				Console.WriteLine($"Error: {response.StatusCode}");
				string errorMessage = await response.Content.ReadAsStringAsync();
			}
		}
	}
}
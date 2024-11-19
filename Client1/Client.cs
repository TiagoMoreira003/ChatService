namespace Client1
{
	public class Client
	{
		public Client()
		{
			Id = Guid.NewGuid();
		}

		public Guid Id { get; private set; }
	}
}
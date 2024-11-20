namespace Server1
{
	public class User
	{
		public User()
		{
		}

		public User(string username, string password) : this()
		{
			Username = username;
			Password = password;
		}

		public Guid Id { get; private set; }
		public string Password { get; private set; }
		public string Username { get; private set; }
	}
}
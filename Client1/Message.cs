namespace Client1
{
	public class Message
	{
		public Message(string text, Guid id)
		{
			this.Text = text;
			this.Id = id;
			Time = DateTime.Now;
		}

		public Guid Id { get; private set; }
		public string Text { get; private set; }
		public DateTime Time { get; private set; }
	}
}
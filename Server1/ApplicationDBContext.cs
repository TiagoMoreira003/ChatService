namespace Server1
{
	using Microsoft.EntityFrameworkCore;

	public class ApplicationDBContext : DbContext
	{
		public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
			: base(options) { }

		public DbSet<User> Users { get; set; }
	}
}
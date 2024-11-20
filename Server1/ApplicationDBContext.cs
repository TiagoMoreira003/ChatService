using Microsoft.EntityFrameworkCore;

namespace Server1
{
	public class ApplicationDBContext : DbContext
	{
		public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
			: base(options) { }

		public DbSet<User> Users { get; set; }
	}
}
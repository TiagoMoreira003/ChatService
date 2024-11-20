using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server1.Dtos;

namespace Server1.Controllers
{
	[ApiController]
	[Route("/User")]
	public class UserControllers : Controller
	{
		private readonly ApplicationDBContext _context;

		public UserControllers(ApplicationDBContext context)
		{
			_context = context;
		}

		[HttpPost]
		public async Task<User> CreateAccount([FromBody] CreateUserDto createUser)
		{
			// Verify if the username exists

			if (await _context.Users.AnyAsync(u => u.Username == createUser.Username))
			{
				throw new Exception("Already Exists!");
			}

			User User = new User(createUser.Username, createUser.Password);

			await _context.AddAsync(User);
			await _context.SaveChangesAsync();

			return User;
		}

		[HttpGet("/{Username}&{Password}")]
		public async Task<User> Login([FromRoute] CreateUserDto createUser)
		{
			// Verify if the username exists
			User user = await _context.Users.FirstOrDefaultAsync(u => u.Username == createUser.Username);

			if (user == null)
			{
				throw new Exception("The user does not exist");
			}

			return user;
		}
	}
}
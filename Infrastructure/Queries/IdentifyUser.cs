using InventoryManagerAPI.Domain.Entities;
using InventoryManagerAPI.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Queries
{
	public class IdentifyUser : IUserQueries
	{
		private readonly ApiDbContext _context;

		public IdentifyUser(ApiDbContext context)
		{
			_context = context;


		}

		/// <summary>
		/// Identifys an user
		/// </summary>
		/// <param name="userName"></param>
		/// <param name="password"></param>
		/// <returns></returns>
		public async Task<User> IdentifyUserQuery(string userName, string password)
		{
			var user = await _context.Users.Where(a => a.UserName == userName && a.Password == password).FirstOrDefaultAsync();
			if (user == null) return null;
			return user;
		}
	}
}

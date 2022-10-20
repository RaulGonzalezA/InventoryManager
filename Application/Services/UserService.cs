using InventoryManagerAPI.Application.Interfaces;
using InventoryManagerAPI.Domain.Interfaces;

namespace InventoryManagerAPI.Application.Services
{
	public class UserService : IUserService
	{
		private readonly IUserQueries _userQueries;

		public UserService(IUserQueries userQueries)
		{
			_userQueries = userQueries;
		}

		public async Task<bool> IdentifyUser(string userName, string password)
		{
			var user = await _userQueries.IdentifyUser(userName, password);
			return user != null;

		}
	}
}

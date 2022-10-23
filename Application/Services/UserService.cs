using InventoryManagerAPI.Application.Interfaces;
using InventoryManagerAPI.Domain.Interfaces;

namespace InventoryManagerAPI.Application.Services
{
	/// <summary>
	/// User service
	/// </summary>
	public class UserService : IUserService
	{
		private readonly IUserQueries _userQueries;

		public UserService(IUserQueries userQueries)
		{
			_userQueries = userQueries;
		}

		/// <summary>
		/// Identifys an user
		/// </summary>
		/// <param name="userName"></param>
		/// <param name="password"></param>
		/// <returns></returns>
		public async Task<bool> IdentifyUser(string userName, string password)
		{
			var user = await _userQueries.IdentifyUserQuery(userName, password);
			return user != null;

		}
	}
}

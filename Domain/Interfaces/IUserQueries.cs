using InventoryManagerAPI.Domain.Entities;

namespace InventoryManagerAPI.Domain.Interfaces
{
	/// <summary>
	/// User Queries Interface
	/// </summary>
	public interface IUserQueries
	{
		/// <summary>
		/// Identifies an user
		/// </summary>
		/// <param name="userName">User name</param>
		/// <param name="password">Password</param>
		/// <returns></returns>
		public Task<User?> IdentifyUserQuery(string userName, string password);
	}
}

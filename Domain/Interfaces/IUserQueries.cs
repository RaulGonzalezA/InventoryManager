using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
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
		public Task<User> IdentifyUser(string userName, string password);
	}
}

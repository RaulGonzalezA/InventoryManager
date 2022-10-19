using Domain;
using Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
	public class UserQueries : IUserQueries
	{
		public UserQueries()
		{
			//Just one time in the constructor
			using (var context = new ApiDbContext())
			{
				var user = new User("Raul", "1234");
				context.Users.Add(user);
				context.SaveChanges();
			}
		}

		/// <summary>
		/// Identifys an user
		/// </summary>
		/// <param name="userName"></param>
		/// <param name="password"></param>
		/// <returns></returns>
		public async Task<User> IdentifyUser(string userName, string password)
		{
			using (var context = new ApiDbContext())
			{
				var user = await context.Users.Where(a => a.UserName == userName && a.Password == password).FirstOrDefaultAsync();
				if (user == null) return null;
				return user;
			}
		}
	}
}

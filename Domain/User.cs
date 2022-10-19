using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
	/// <summary>
	/// User of the aplication
	/// </summary>
	public class User
	{
		/// <summary>
		/// Default constructor
		/// </summary>
		internal User()
		{ }

		/// <summary>
		/// Constructor with parameters
		/// </summary>
		/// <param name="name"></param>
		/// <param name="password"></param>
		public User(string? name, string? password)
		{
			Id = Guid.NewGuid();
			UserName = name;
			Password = password;
		}

		/// <summary>
		/// Id of the user
		/// </summary>
		public Guid Id { get; internal set; }
		/// <summary>
		/// Name of the user
		/// </summary>
		public string? UserName { get; internal set; }
		/// <summary>
		/// Password
		/// </summary>
		public string? Password { get; internal set; }
	}
}

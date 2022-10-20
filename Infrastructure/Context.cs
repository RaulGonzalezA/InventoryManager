using InventoryManagerAPI.Domain;
using InventoryManagerAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
	/// <summary>
	/// Context of the aplication
	/// </summary>
	public class ApiDbContext : DbContext
	{
		protected override void OnConfiguring
	   (DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseInMemoryDatabase(databaseName: "InventoryManager");
		}

		/// <summary>
		/// Table of items
		/// </summary>
		public DbSet<Item> Items { get; set; }

		/// <summary>
		/// Table of Users
		/// </summary>
		public DbSet<User> Users { get; set; }

	}
}

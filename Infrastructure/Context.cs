using InventoryManagerAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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

using Infrastructure;
using InventoryManagerAPI.Domain.Entities;
using InventoryManagerAPI.Domain.Enums;

namespace InventoryManagerAPI.Infrastructure.Seeder
{
	/// <summary>
	/// Data seeder
	/// </summary>
	public class DataSeeder
	{
		private readonly ApiDbContext _context;

		/// <summary>
		/// default constructor
		/// </summary>
		/// <param name="context"></param>
		public DataSeeder(ApiDbContext context)
		{
			_context = context;
		}

		public void Seed()
		{
			if (!_context.Items.Any())
			{
				_context.Items.AddRange(new Item(Guid.NewGuid(), "Bicycle 1", ObjectTypeEnum.Bike, 100, 2), new Item(Guid.NewGuid(), "Video Game 1", ObjectTypeEnum.Videogame, 150, 6));
				_context.SaveChanges();
			}

			if (!_context.Users.Any())
			{
				_context.Users.AddRange(new User("Raul", "1234"), new User("Test", "1234"));
				_context.SaveChanges();
			}
		}
	}
}

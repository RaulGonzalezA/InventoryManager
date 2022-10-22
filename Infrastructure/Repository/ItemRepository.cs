using InventoryManagerAPI.Domain.Entities;
using InventoryManagerAPI.Domain.Interfaces;

namespace Infrastructure.Repository
{
	/// <summary>
	/// Item repository implementaiton
	/// </summary>
	public class ItemRepository : IItemRepository
	{
		private readonly ApiDbContext _context;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="context"></param>
		public ItemRepository(ApiDbContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Add new item
		/// </summary>
		/// <param name="item">new item</param>
		/// <returns>the new item</returns>
		public async Task<Item> AddAsync(Item item)
		{
			using (_context)
			{
				var itemResult = await _context.Items.AddAsync(item);
				await _context.SaveChangesAsync();

				return itemResult.Entity;
			}
		}

		/// <summary>
		/// Removes an item by name
		/// </summary>
		/// <param name="item">Item to remove</param>
		/// <returns>If the item was removed or not</returns>
		public async Task<bool> RemoveItemAsync(Item item)
		{
			using (_context)
			{
				var result = _context.Items.Remove(item);
				await _context.SaveChangesAsync();
			}

			return true;
		}
	}
}

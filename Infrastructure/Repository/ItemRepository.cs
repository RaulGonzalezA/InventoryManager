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
			var itemResult = await _context.Items.AddAsync(item);
			await _context.SaveChangesAsync();

			return itemResult.Entity;
		}

		/// <summary>
		/// Removes an item by name
		/// </summary>
		/// <param name="item">Item to remove</param>
		/// <returns>If the item was removed or not</returns>
		public async Task<bool> RemoveItemAsync(Item item)
		{
			var result = _context.Items.Remove(item);
			await PublishEvents(item);
			await _context.SaveChangesAsync();

			return true;
		}

		private async Task PublishEvents(Item item)
		{
			var events = item.DomainEvents.ToArray();
			if (events.Any())
			{
				item.DomainEvents.Clear();
				foreach (var domainEvents in events)
				{
					await _context._publisher.Publish(domainEvents);
				}
			}
		}

		/// <summary>
		/// Removes an item
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		/// <exception cref="NotImplementedException"></exception>
		public async Task<Item> UpdateItemAsync(Item item)
		{
			var result = _context.Items.Update(item);
			await PublishEvents(item);
			await _context.SaveChangesAsync();

			return result.Entity;
		}
	}
}

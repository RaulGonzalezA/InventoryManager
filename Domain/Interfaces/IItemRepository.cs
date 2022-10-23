using InventoryManagerAPI.Domain.Entities;

namespace InventoryManagerAPI.Domain.Interfaces
{
	/// <summary>
	/// Repository to manage Items
	/// </summary>
	public interface IItemRepository
	{
		/// <summary>
		/// Add new item
		/// </summary>
		/// <param name="item">new item</param>
		/// <returns>the new item</returns>
		public Task<Item> AddAsync(Item item);

		/// <summary>
		/// Removes an item by name
		/// </summary>
		/// <param name="item">Item to remove</param>
		/// <returns>If the item was removed or not</returns>
		public Task<bool> RemoveItemAsync(Item item);

		/// <summary>
		/// Updates an item
		/// </summary>
		/// <param name="item">Item to update</param>
		/// <returns></returns>
		public Task<Item> UpdateItemAsync(Item item);
	}
}

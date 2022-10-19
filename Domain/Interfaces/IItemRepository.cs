using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
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
		public  Task<Item> AddAsync(Item item);

		/// <summary>
		/// Removes an item by name
		/// </summary>
		/// <param name="name">Name of the item to remove</param>
		/// <returns>If the item was removed or not</returns>
		public Task<bool> RemoveItemAsync(string name);
	}
}

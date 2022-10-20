using InventoryManagerAPI.Domain;
using InventoryManagerAPI.Domain.Entities;
using InventoryManagerAPI.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
	/// <summary>
	/// Item repository implementaiton
	/// </summary>
	public class ItemRepository : IItemRepository
	{
		/// <summary>
		/// Add new item
		/// </summary>
		/// <param name="item">new item</param>
		/// <returns>the new item</returns>
		public async Task<Item> AddAsync(Item item)
		{
			using (var context = new ApiDbContext())
			{
				var itemResult = await context.Items.AddAsync(item);
				await context.SaveChangesAsync();

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
			using (var context = new ApiDbContext())
			{
				var result = context.Items.Remove(item);
				await context.SaveChangesAsync();
			}

			return true;
		}
	}
}

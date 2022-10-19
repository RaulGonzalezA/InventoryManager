using Domain;
using Domain.Interfaces;
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
				context.SaveChanges();

				return itemResult.Entity;
			}
		}

		/// <summary>
		/// Removes an item by name
		/// </summary>
		/// <param name="name">Name of the item to remove</param>
		/// <returns>If the item was removed or not</returns>
		public async Task<bool> RemoveItemAsync(string name)
		{
			using (var context = new ApiDbContext())
			{
				var item = await context.Items.Where(x => x.Name == name).FirstOrDefaultAsync();
				
				if (item == null)
					return false;
				
				var result = context.Items.Remove(item);
				context.SaveChanges();
			}

			return true;
		}
	}
}

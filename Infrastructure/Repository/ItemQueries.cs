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
	public class ItemQueries : IItemQueries
	{
		public async Task<Item> GetItemByName(string name)
		{
			using (var context = new ApiDbContext())
			{
				var item = await context.Items.Where(x => x.Name == name).FirstOrDefaultAsync();

				return item;
			}
		}
	}
}

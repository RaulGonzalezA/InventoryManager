using Infrastructure;
using InventoryManagerAPI.Domain.Entities;
using InventoryManagerAPI.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagerAPI.Infrastructure.Queries
{
	public class GetItems : IGetItems
	{
		private readonly ApiDbContext _context;

		public GetItems(ApiDbContext context)
		{
			_context = context;
		}

		public async Task<List<Item>> GetItemsQuery()
		{
			var items = await _context.Items.ToListAsync();
			return items;
		}
	}
}

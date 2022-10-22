using InventoryManagerAPI.Domain.Entities;
using InventoryManagerAPI.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Queries
{
	public class GetItemByName : IItemQueries
	{
		private readonly ApiDbContext _context;

		public GetItemByName(ApiDbContext context)
		{
			_context = context;
		}

		public async Task<Item> GetItemByNameQuery(string name)
		{
			using (_context)
			{
				var item = await _context.Items.Where(x => x.Name == name).FirstOrDefaultAsync();

				return item;
			}
		}
	}
}

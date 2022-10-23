using InventoryManagerAPI.Domain.Entities;
using InventoryManagerAPI.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Queries
{
	public class GetItemByName : IGetItemByName
	{
		private readonly ApiDbContext _context;

		public GetItemByName(ApiDbContext context)
		{
			_context = context;
		}

		public async Task<Item> GetItemByNameQuery(string name)
		{
			var item = await _context.Items.Where(x => x.Name == name).FirstOrDefaultAsync();

			return item;
		}
	}
}

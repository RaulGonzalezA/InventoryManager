using InventoryManagerAPI.Domain.Entities;

namespace InventoryManagerAPI.Domain.Interfaces
{
	public interface IItemQueries
	{
		public Task<Item> GetItemByNameQuery(string name);
	}
}

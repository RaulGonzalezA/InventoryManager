using InventoryManagerAPI.Domain.Entities;

namespace InventoryManagerAPI.Domain.Interfaces
{
	public interface IGetItemByName
	{
		public Task<Item> GetItemByNameQuery(string name);
	}
}

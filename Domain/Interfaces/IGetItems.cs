using InventoryManagerAPI.Domain.Entities;

namespace InventoryManagerAPI.Domain.Interfaces
{
	public interface IGetItems
	{
		public Task<List<Item>> GetItemsQuery();
	}
}

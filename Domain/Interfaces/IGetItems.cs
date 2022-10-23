using InventoryManagerAPI.Domain.Entities;

namespace InventoryManagerAPI.Domain.Interfaces
{
	/// <summary>
	/// Interface Get Items
	/// </summary>
	public interface IGetItems
	{
		public Task<List<Item>> GetItemsQuery();
	}
}

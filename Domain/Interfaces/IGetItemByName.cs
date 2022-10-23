using InventoryManagerAPI.Domain.Entities;

namespace InventoryManagerAPI.Domain.Interfaces
{
	/// <summary>
	/// Interface Get Item by Name
	/// </summary>
	public interface IGetItemByName
	{
		public Task<Item> GetItemByNameQuery(string name);
	}
}

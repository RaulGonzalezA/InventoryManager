using InventoryManagerAPI.Application.Models;

namespace InventoryManagerAPI.Application.Interfaces
{
	public interface IItemService
	{
		public Task<ItemCreatedDTO> CreateItem(ItemDTO item);
		public Task<bool> DeleteItem(string name);
	}
}

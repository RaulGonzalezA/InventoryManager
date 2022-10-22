using InventoryManagerAPI.Domain.Entities.Models;

namespace InventoryManagerAPI.Application.Interfaces
{
	public interface IItemService
	{
		public Task<bool> DeleteItem(string name);
	}
}

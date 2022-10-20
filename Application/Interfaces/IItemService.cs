using InventoryManagerAPI.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagerAPI.Application.Interfaces
{
	public interface IItemService
	{
		public Task<ItemCreatedDTO> CreateItem(ItemDTO item);
		public Task<bool> DeleteItem(string name);
	}
}

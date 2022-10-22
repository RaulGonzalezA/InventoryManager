using InventoryManagerAPI.Application.Interfaces;
using InventoryManagerAPI.Domain.Entities;
using InventoryManagerAPI.Domain.Entities.Models;
using InventoryManagerAPI.Domain.Exceptions;
using InventoryManagerAPI.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace InventoryManagerAPI.Application.Services
{
	/// <summary>
	/// Item service
	/// </summary>
	public class ItemService : IItemService
	{
		private readonly IItemRepository _itemRepository;
		private readonly ILogger<ItemService> _logger;
		private readonly IItemQueries _itemQueries;

		/// <summary>
		/// Constructor of the service
		/// </summary>
		/// <param name="itemRepository"></param>
		/// <param name="logger"></param>
		/// <param name="itemQueries"></param>
		public ItemService(IItemRepository itemRepository, ILogger<ItemService> logger, IItemQueries itemQueries)
		{
			_itemRepository = itemRepository;
			_logger = logger;
			_itemQueries = itemQueries;
		}

		/// <summary>
		/// Deletes a item
		/// </summary>
		/// <param name="name">Name of the item to delete</param>
		/// <returns>If the item was deleted or not</returns>
		public async Task<bool> DeleteItem(string name)
		{
			Item item;
			try
			{
				item = await _itemQueries.GetItemByNameQuery(name);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Error getting item to delete {ex.Message}");
				throw new Exception("Error getting item to delete", ex);
			}

			if (item == null)
				throw new NotFoundException("Item not found");

			return await _itemRepository.RemoveItemAsync(item);
		}
	}
}

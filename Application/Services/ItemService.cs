using InventoryManagerAPI.Application.Interfaces;
using InventoryManagerAPI.Application.Models;
using InventoryManagerAPI.Domain.Entities;
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
		/// Creates a new item
		/// </summary>
		/// <param name="itemModel"></param>
		/// <returns></returns>
		/// <exception cref="Exception"></exception>
		public async Task<ItemCreatedDTO> CreateItem(ItemDTO itemModel)
		{
			try
			{
				Item item = new Item(Guid.NewGuid(), itemModel.Name, itemModel.ExpirationDate, itemModel.Type, itemModel.Price, itemModel.Amount);

				item = await _itemRepository.AddAsync(item);

				return new ItemCreatedDTO(item.Id, item.Name, item.ExpirationDate, item.Type, item.Price, item.Amount);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Error creating item {ex.Message}");
				throw new Exception("Error creating item", ex);
			}
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
				item = await _itemQueries.GetItemByName(name);
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

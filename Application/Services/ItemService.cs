using Application.Interfaces;
using Application.Models;
using Domain;
using Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
	public class ItemService : IItemService
	{
		private readonly IItemRepository _itemRepository;
		private readonly ILogger<ItemService> _logger;

		public ItemService(IItemRepository itemRepository, ILogger<ItemService> logger)
		{
			_itemRepository = itemRepository;
			_logger = logger;
		}

		public async Task<ItemCreatedModel> CreateItem(ItemModel itemModel)
		{
			try
			{
				Item item = new Item(itemModel.Name, itemModel.ExpirationDate, itemModel.Type, itemModel.Price, itemModel.Amount);

				item = await _itemRepository.AddAsync(item);

				return new ItemCreatedModel(item.Id, item.Name, item.ExpirationDate, item.Type, item.Price, item.Amount);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Error creating item {ex.Message}");
				throw new Exception("Error creating item", ex);
			}
		}
	}
}

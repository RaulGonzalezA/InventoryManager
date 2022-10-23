using InventoryManagerAPI.Domain.Entities;
using InventoryManagerAPI.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InventoryManagerAPI.Application.Commands
{
	/// <summary>
	/// Request for delete the item
	/// </summary>
	public class DeleteItemCommand : IRequest<IActionResult>
	{
		/// <summary>
		/// Name of the item
		/// </summary>
		public string? Name { get; set; }
	}

	/// <summary>
	/// Delete Item Command Handler
	/// </summary>
	public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand, IActionResult>
	{
		private readonly IItemRepository _itemRepository;
		private readonly ILogger<CreateItemCommandHandler> _logger;
		private readonly IGetItemByName _itemQueries;

		public DeleteItemCommandHandler(IItemRepository itemRepository, ILogger<CreateItemCommandHandler> logger, IGetItemByName itemQueries)
		{
			_itemRepository = itemRepository;
			_logger = logger;
			_itemQueries = itemQueries;
		}

		/// <summary>
		/// Handler
		/// </summary>
		/// <param name="request"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public async Task<IActionResult> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
		{
			Item item;
			try
			{
				item = await _itemQueries.GetItemByNameQuery(request.Name);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Error getting item to delete {ex.Message}");
				return new BadRequestObjectResult($"Error getting item to delete: {ex.Message}");
			}

			if (item == null)
				return new NotFoundObjectResult(request.Name);

			var itemDeleted = Item.DeleteItem(item);

			bool removed = await _itemRepository.RemoveItemAsync(itemDeleted);

			if (removed)
				return new NoContentResult();
			else
				return new BadRequestObjectResult($"Error removing item {request.Name}");
		}
	}
}

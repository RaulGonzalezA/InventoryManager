using FluentValidation.Results;
using InventoryManagerAPI.Application.Validators;
using InventoryManagerAPI.Domain.Entities;
using InventoryManagerAPI.Domain.Enums;
using InventoryManagerAPI.Domain.Interfaces;
using InventoryManagerAPI.Domain.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace InventoryManagerAPI.Application.Commands
{
	/// <summary>
	/// Update Item Command
	/// </summary>
	public class UpdateItemCommand : IRequest<IActionResult>
	{
		public UpdateItemCommand(string? name, ObjectTypeEnum type, decimal price, int amount, DateTime? expirationDate = null)
		{
			Name = name;
			ExpirationDate = expirationDate;
			Type = type;
			Price = price;
			Amount = amount;
		}

		/// <summary>
		/// Name of the item
		/// </summary>
		public string? Name { get; set; }
		/// <summary>
		/// Date expiration of the item
		/// </summary>
		public DateTime? ExpirationDate { get; set; }
		/// <summary>
		/// Type of item
		/// </summary>
		public ObjectTypeEnum Type { get; set; }
		/// <summary>
		/// Price of the item
		/// </summary>
		public decimal Price { get; set; }
		/// <summary>
		/// Amount of items
		/// </summary>
		public int Amount { get; set; }
	}

	/// <summary>
	/// Update Item Command Handler
	/// </summary>
	public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand, IActionResult>
	{
		private readonly IItemRepository _itemRepository;
		private readonly ILogger<UpdateItemCommandHandler> _logger;
		private readonly IGetItemByName _itemQueries;

		public UpdateItemCommandHandler(IItemRepository itemRepository, ILogger<UpdateItemCommandHandler> logger, IGetItemByName itemQueries)
		{
			_itemRepository = itemRepository;
			_logger = logger;
			_itemQueries = itemQueries;
		}

		/// <summary>
		/// Handler of command
		/// </summary>
		/// <param name="request"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public async Task<IActionResult> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
		{
			UpdateItemFluentValidator validator = new UpdateItemFluentValidator();
			ValidationResult results = validator.Validate(request);
			if (!results.IsValid)
			{
				_logger.LogError($"Error in the model: {JsonConvert.SerializeObject(results.Errors)}");
				return new BadRequestObjectResult(JsonConvert.SerializeObject(results.Errors));
			}

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

			item.UpdateItem(request.Name, request.Type, request.Price, request.Amount, request.ExpirationDate);

			ItemResponse result = await _itemRepository.UpdateItemAsync(item);

			return new OkObjectResult(result);
		}
	}
}

using InventoryManagerAPI.Application.Validators;
using InventoryManagerAPI.Domain.Entities;
using InventoryManagerAPI.Domain.Enums;
using InventoryManagerAPI.Domain.Interfaces;
using InventoryManagerAPI.Domain.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace InventoryManagerAPI.Application.Commands
{
	/// <summary>
	/// Request for create the Item
	/// </summary>
	public class CreateItemCommand : IRequest<IActionResult>
	{
		public CreateItemCommand(string? name, ObjectTypeEnum type, decimal price, int amount)
		{
			Name = name;
			Type = type;
			Price = price;
			Amount = amount;
		}

		/// <summary>
		/// Name of the item
		/// </summary>
		public string? Name { get; set; }
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
	/// Create Item Command Handler
	/// </summary>
	public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, IActionResult>
	{
		private readonly IItemRepository _itemRepository;
		private readonly ILogger<CreateItemCommandHandler> _logger;

		public CreateItemCommandHandler(IItemRepository itemRepository, ILogger<CreateItemCommandHandler> logger)
		{
			_itemRepository = itemRepository;
			_logger = logger;
		}

		/// <summary>
		/// Handler
		/// </summary>
		/// <param name="request"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public async Task<IActionResult> Handle(CreateItemCommand request, CancellationToken cancellationToken)
		{
			CreateItemFluentValidator validator = new CreateItemFluentValidator();
			ValidationResult results = validator.Validate(request);
			if (!results.IsValid)
			{
				_logger.LogError($"Error in the model: {JsonConvert.SerializeObject(results.Errors)}");
				return new BadRequestObjectResult(JsonConvert.SerializeObject(results.Errors));
			}
			try
			{
				Item item = new Item(Guid.NewGuid(), request.Name, request.Type, request.Price, request.Amount);

				ItemResponse itemResult = await _itemRepository.AddAsync(item);

				return new CreatedResult("", item);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Error creating item {ex.Message}");
				return new BadRequestObjectResult($"Error creating item: {ex.Message}");
			}
		}
	}
}

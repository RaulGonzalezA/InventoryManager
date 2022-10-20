using InventoryManagerAPI.Domain.Exceptions;
using InventoryManagerAPI.Application.Interfaces;
using InventoryManagerAPI.Application.Models;
using FluentValidation.Results;
using InventoryManagerAPI.Host.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace InventoryManagerAPI.Host.Controllers
{
	/// <summary>
	/// Item Controller
	/// </summary>
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class ItemController : ControllerBase
	{
		private readonly IItemService _itemService;
		private readonly ILogger<ItemController> _logger;

		/// <summary>
		/// Item Controller constructor
		/// </summary>
		/// <param name="itemService"></param>
		/// <param name="logger"></param>
		public ItemController(IItemService itemService, ILogger<ItemController> logger)
		{
			_itemService = itemService;
			_logger = logger;
		}

		/// <summary>
		/// Add new Item to the Inventory
		/// </summary>
		/// <param name="itemModel">Item</param>
		/// <returns>The new item created</returns>
		/// <remarks>
		/// Sample request:
		///  {
		///     "name": "string",
		///     "expirationDate": "2022-10-18T18:59:37.411Z",
		///     "type": 0,
		///     "price": 0,
		///     "amount": 0
		///  }
		/// </remarks>
		/// <response code="201">New object created</response>
		/// <response code="400">If any error into the response</response>
		/// <response code="401">If not authorized</response>
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] ItemDTO itemModel)
		{
			ItemFluentValidator validator = new ItemFluentValidator();
			ValidationResult results = validator.Validate(itemModel);

			if (!results.IsValid)
			{
				_logger.LogError($"Error in the model: {JsonConvert.SerializeObject(results.Errors)}");
				return BadRequest(JsonConvert.SerializeObject(results.Errors));
			}

			try
			{
				var itemCreated = await _itemService.CreateItem(itemModel);
				return Created("", itemCreated);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Error creating Item: {ex.Message}");
				return BadRequest(ex.Message);
			}
		}

		/// <summary>
		/// Delete an Item
		/// </summary>
		/// <param name="name">Name of the item</param>
		/// <returns></returns>
		/// <response code="204">If the item was deleted</response>
		/// <response code="400">If any error into the response</response>
		/// <response code="401">If not authorized</response>
		/// <response code="404">If not found the item</response>
		[HttpDelete("{name}")]
		public async Task<IActionResult> Delete([FromRoute] string name)
		{
			if (string.IsNullOrWhiteSpace(name))
			{
				return BadRequest($"{nameof(name)} cant be Null or whitespace.");
			}

			try
			{
				var deleted = await _itemService.DeleteItem(name);
				if (!deleted)
				{
					_logger.LogError($"Item with name {name} not deleted");
					return BadRequest($"Item with name {name} not deleted");
				}
			}
			catch (NotFoundException ex)
			{
				_logger.LogError($"Item with name {name} not found: {ex.Message}");
				return NotFound(name);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Error deleting Item with name {name}: {ex.Message}");
				return BadRequest(ex.Message);
			}

			return NoContent();
		}
	}
}

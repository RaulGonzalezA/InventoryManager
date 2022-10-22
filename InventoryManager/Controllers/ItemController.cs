using FluentValidation.Results;
using InventoryManagerAPI.Application.Commands;
using InventoryManagerAPI.Application.Interfaces;
using InventoryManagerAPI.Domain.Entities.Models;
using InventoryManagerAPI.Domain.Exceptions;
using MediatR;
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
		private readonly IMediator _mediator;

		/// <summary>
		/// Item Controller constructor
		/// </summary>
		/// <param name="mediator"></param>
		public ItemController(IMediator mediator)
		{
			_mediator = mediator;
		}

		/// <summary>
		/// Add new Item to the Inventory
		/// </summary>
		/// <param name="request">Item</param>
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
		[HttpPost("", Name = nameof(ItemController.CreateItem))]
		public async Task<IActionResult> CreateItem([FromBody] CreateItemCommand request)
		{

			try
			{
				var result = await _mediator.Send(request);
				return result;
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		/// <summary>
		/// Delete an Item by name from the inventory
		/// </summary>
		/// <param name="name">Name of the item</param>
		/// <returns></returns>
		/// <response code="204">If the item was deleted</response>
		/// <response code="400">If any error into the response</response>
		/// <response code="401">If not authorized</response>
		/// <response code="404">If not found the item</response>
		[HttpDelete("{name}", Name = nameof(ItemController.DeleteItem))]
		public async Task<IActionResult> DeleteItem([FromRoute] string name)
		{
			//if (string.IsNullOrWhiteSpace(name))
			//{
			//	return BadRequest($"{nameof(name)} cant be Null or whitespace.");
			//}

			//try
			//{
			//	var deleted = await _itemService.DeleteItem(name);
			//	if (!deleted)
			//	{
			//		_logger.LogError($"Item with name {name} not deleted");
			//		return BadRequest($"Item with name {name} not deleted");
			//	}
			//}
			//catch (NotFoundException ex)
			//{
			//	_logger.LogError($"Item with name {name} not found: {ex.Message}");
			//	return NotFound(name);
			//}
			//catch (Exception ex)
			//{
			//	_logger.LogError($"Error deleting Item with name {name}: {ex.Message}");
			//	return BadRequest(ex.Message);
			//}

			return NoContent();
		}
	}
}

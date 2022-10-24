using InventoryManagerAPI.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
		/// <param name="request">Name of the item</param>
		/// <returns></returns>
		/// <response code="204">If the item was deleted</response>
		/// <response code="400">If any error into the response</response>
		/// <response code="401">If not authorized</response>
		/// <response code="404">If not found the item</response>
		[HttpDelete("", Name = nameof(ItemController.DeleteItem))]
		public async Task<IActionResult> DeleteItem([FromBody] DeleteItemCommand request)
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
		/// Update an Item by name from the inventory
		/// </summary>
		/// <param name="request">Item to update</param>
		/// <returns></returns>
		/// <response code="201">If the item was updated</response>
		/// <response code="400">If any error into the response</response>
		/// <response code="401">If not authorized</response>
		/// <response code="404">If not found the item</response>
		[HttpPut("", Name = nameof(ItemController.UpdateItem))]
		public async Task<IActionResult> UpdateItem([FromBody] UpdateItemCommand request)
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
		/// Gets all Items from the inventory
		/// </summary>
		/// <returns></returns>
		/// <response code="200">The list of itemsd</response>
		/// <response code="400">If any error into the response</response>
		/// <response code="401">If not authorized</response>
		[HttpGet("", Name = nameof(ItemController.GetItems))]
		public async Task<IActionResult> GetItems()
		{
			try
			{
				GetItemsCommand request = new GetItemsCommand();
				var result = await _mediator.Send(request);
				return result;
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}

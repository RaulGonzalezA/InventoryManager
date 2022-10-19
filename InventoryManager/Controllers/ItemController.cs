using Application.Interfaces;
using Application.Models;
using FluentValidation.Results;
using InventoryManagerAPI.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace InventoryManagerAPI.Controllers
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
		public async Task<IActionResult> Post([FromBody] ItemModel itemModel)
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
				return BadRequest(ex.Message);
			}
		}
	}
}

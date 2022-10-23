using InventoryManagerAPI.Domain.Interfaces;
using InventoryManagerAPI.Domain.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InventoryManagerAPI.Application.Commands
{
	public class GetItemsCommand : IRequest<IActionResult>
	{
	}

	public class GetItemsCommandHandler : IRequestHandler<GetItemsCommand, IActionResult>
	{

		private readonly ILogger<CreateItemCommandHandler> _logger;
		private readonly IGetItems _getItems;

		public GetItemsCommandHandler(ILogger<CreateItemCommandHandler> logger, IGetItems getItems)
		{
			_logger = logger;
			_getItems = getItems;
		}

		public async Task<IActionResult> Handle(GetItemsCommand request, CancellationToken cancellationToken)
		{
			try
			{
				var items = await _getItems.GetItemsQuery();
				List<ItemResponse> result = new List<ItemResponse>();
				items.ForEach(item => result.Add(item));
				return new OkObjectResult(result);
			}
			catch (Exception ex)
			{
				return new BadRequestObjectResult($"Error getting Items: {ex.Message}");
			}
		}
	}
}

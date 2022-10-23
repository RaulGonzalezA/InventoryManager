using InventoryManagerAPI.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InventoryManagerAPI.Application.Handlers
{
	public class ItemExpiredEventHandler : INotificationHandler<ItemExpiredEvent>
	{
		private readonly ILogger<ItemExpiredEventHandler> _logger;

		public ItemExpiredEventHandler(ILogger<ItemExpiredEventHandler> logger)
		{
			_logger = logger;
		}

		public Task Handle(ItemExpiredEvent notification, CancellationToken cancellationToken)
		{
			_logger.LogInformation($"Item expired: {notification.Item.Name}");
			return Task.CompletedTask;
		}
	}
}

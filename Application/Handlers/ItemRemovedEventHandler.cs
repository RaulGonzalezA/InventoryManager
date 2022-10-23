using InventoryManagerAPI.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InventoryManagerAPI.Application.Handlers
{
	public class ItemRemovedEventHandler : INotificationHandler<ItemRemovedEvent>
	{
		private readonly ILogger<ItemRemovedEventHandler> _logger;

		public ItemRemovedEventHandler(ILogger<ItemRemovedEventHandler> logger)
		{
			_logger = logger;
		}

		public Task Handle(ItemRemovedEvent notification, CancellationToken cancellationToken)
		{
			_logger.LogInformation($"Item removed: {notification.Item.Name}");
			return Task.CompletedTask;
		}
	}
}

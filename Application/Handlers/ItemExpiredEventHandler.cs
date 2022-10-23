using InventoryManagerAPI.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InventoryManagerAPI.Application.Handlers
{
	/// <summary>
	/// Item Expired Event handler
	/// </summary>
	public class ItemExpiredEventHandler : INotificationHandler<ItemExpiredEvent>
	{
		private readonly ILogger<ItemExpiredEventHandler> _logger;

		public ItemExpiredEventHandler(ILogger<ItemExpiredEventHandler> logger)
		{
			_logger = logger;
		}

		/// <summary>
		/// Handler of event
		/// </summary>
		/// <param name="notification"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public Task Handle(ItemExpiredEvent notification, CancellationToken cancellationToken)
		{
			_logger.LogInformation($"Item expired: {notification.Item.Name}");
			return Task.CompletedTask;
		}
	}
}

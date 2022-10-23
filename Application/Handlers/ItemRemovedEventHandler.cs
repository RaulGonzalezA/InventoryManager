using InventoryManagerAPI.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InventoryManagerAPI.Application.Handlers
{
	/// <summary>
	/// Item Removed Event Handler
	/// </summary>
	public class ItemRemovedEventHandler : INotificationHandler<ItemRemovedEvent>
	{
		private readonly ILogger<ItemRemovedEventHandler> _logger;

		public ItemRemovedEventHandler(ILogger<ItemRemovedEventHandler> logger)
		{
			_logger = logger;
		}

		/// <summary>
		/// Handler
		/// </summary>
		/// <param name="notification"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public Task Handle(ItemRemovedEvent notification, CancellationToken cancellationToken)
		{
			_logger.LogInformation($"Item removed: {notification.Item.Name}");
			return Task.CompletedTask;
		}
	}
}

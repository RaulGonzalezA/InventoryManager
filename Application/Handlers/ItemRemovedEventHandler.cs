using InventoryManagerAPI.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagerAPI.Application.Handlers
{
	public class ItemRemovedEventHandler : INotificationHandler<ItemRemovedEvent>
	{
		private readonly ILogger<ItemRemovedEventHandler> _logger;

		public ItemRemovedEventHandler(ILogger<ItemRemovedEventHandler> logger)
		{
			_logger = logger;
		}

		public async Task Handle(ItemRemovedEvent notification, CancellationToken cancellationToken)
		{
			_logger.LogInformation($"Item removed: {notification.Item.Name}");
		}
	}
}

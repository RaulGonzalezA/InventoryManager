using InventoryManagerAPI.Domain.Entities;

namespace InventoryManagerAPI.Domain.Events
{
	public class ItemExpiredEvent : DomainEvent
	{
		public ItemExpiredEvent(Item item)
		{
			Item = item;
		}

		public Item Item { get; set; }
	}
}

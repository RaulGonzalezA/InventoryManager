using InventoryManagerAPI.Domain.Entities;

namespace InventoryManagerAPI.Domain.Events
{
	public class ItemRemovedEvent : DomainEvent
	{
		public ItemRemovedEvent(Item item)
		{
			Item = item;
		}

		public Item Item { get; set; }
	}
}

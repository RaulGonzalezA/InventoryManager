using InventoryManagerAPI.Domain.Entities;

namespace InventoryManagerAPI.Domain.Events
{
	/// <summary>
	/// Item Removed Event
	/// </summary>
	public class ItemRemovedEvent : DomainEvent
	{
		public ItemRemovedEvent(Item item)
		{
			Item = item;
		}

		/// <summary>
		/// Item
		/// </summary>
		public Item Item { get; set; }
	}
}

using InventoryManagerAPI.Domain.Entities;

namespace InventoryManagerAPI.Domain.Events
{
	/// <summary>
	/// Item Expired Event
	/// </summary>
	public class ItemExpiredEvent : DomainEvent
	{
		public ItemExpiredEvent(Item item)
		{
			Item = item;
		}

		/// <summary>
		/// Item
		/// </summary>
		public Item Item { get; set; }
	}
}

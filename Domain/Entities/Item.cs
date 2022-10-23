using InventoryManagerAPI.Domain.Enums;
using InventoryManagerAPI.Domain.Events;
using InventoryManagerAPI.Domain.Responses;

namespace InventoryManagerAPI.Domain.Entities
{
	/// <summary>
	/// Item of the inventory
	/// </summary>
	public class Item : ItemResponse, IHasDomainEvent
	{
		/// <summary>
		/// Default constructor
		/// </summary>
		internal Item()
		{
		}

		public Item(Guid id, string name, ObjectTypeEnum type, decimal price, int amount, DateTime? expirationDate = null)
		{
			Id = id;
			Name = name;
			ExpirationDate = expirationDate;
			Type = type;
			Price = price;
			Amount = amount;
		}

		public static Item DeleteItem(Item item)
		{
			var itemResult = item;
			itemResult.DomainEvents.Add(new ItemRemovedEvent(itemResult));

			return itemResult;
		}

		public void UpdateItem(string name, ObjectTypeEnum type, decimal price, int amount, DateTime? expirationDate = null)
		{
			Name = name;
			Type = type;
			Price = price;
			Amount = amount;
			ExpirationDate = expirationDate;

			if (expirationDate <= DateTime.Now)
				this.DomainEvents.Add(new ItemExpiredEvent(this));

		}
		/// <summary>
		/// Domain events
		/// </summary>
		public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
	}
}

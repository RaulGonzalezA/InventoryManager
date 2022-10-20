using InventoryManagerAPI.Domain.Enums;

namespace InventoryManagerAPI.Domain.Entities
{
	/// <summary>
	/// Item of the inventory
	/// </summary>
	public class Item
	{
		/// <summary>
		/// Default constructor
		/// </summary>
		internal Item()
		{
		}

		public Item(Guid id, string name, DateTime expirationDate, ObjectTypeEnum type, decimal price, int amount)
		{
			Id = id;
			Name = name;
			ExpirationDate = expirationDate;
			Type = type;
			Price = price;
			Amount = amount;
		}

		/// <summary>
		/// Id of the Item
		/// </summary>
		public Guid Id { get; internal set; }
		/// <summary>
		/// Name of the item
		/// </summary>
		public string? Name { get; internal set; }
		/// <summary>
		/// Date expiration of the item
		/// </summary>
		public DateTime ExpirationDate { get; internal set; }
		/// <summary>
		/// Type of item
		/// </summary>
		public ObjectTypeEnum Type { get; internal set; }
		/// <summary>
		/// Price of the item
		/// </summary>
		public decimal Price { get; internal set; }
		/// <summary>
		/// Amount of items
		/// </summary>
		public int Amount { get; internal set; }
	}
}

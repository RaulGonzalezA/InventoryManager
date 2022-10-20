using InventoryManagerAPI.Domain.Enums;

namespace InventoryManagerAPI.Domain.Entities.Models
{
	/// <summary>
	/// Item created model
	/// </summary>
	public class ItemCreatedDTO : ItemDTO
	{
		/// <summary>
		/// Constructor for Item created
		/// </summary>
		/// <param name="id"></param>
		/// <param name="name"></param>
		/// <param name="expirationDate"></param>
		/// <param name="type"></param>
		/// <param name="price"></param>
		/// <param name="amount"></param>
		public ItemCreatedDTO(Guid id, string? name, DateTime expirationDate, ObjectTypeEnum type, decimal price, int amount)
		{
			Id = id;
			Name = name;
			ExpirationDate = expirationDate;
			Type = type;
			Price = price;
			Amount = amount;
		}

		/// <summary>
		/// Id of the item
		/// </summary>
		public Guid Id { get; set; }
	}
}

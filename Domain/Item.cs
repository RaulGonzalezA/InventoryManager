using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
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

		public Item(string name, DateTime expirationDate, ObjectTypeEnum type, decimal price, int amount)
		{
			Id = Guid.NewGuid();
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

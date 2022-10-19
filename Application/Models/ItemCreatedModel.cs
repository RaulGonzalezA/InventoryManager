using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
	/// <summary>
	/// Item created model
	/// </summary>
	public class ItemCreatedModel : ItemModel
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
		public ItemCreatedModel(Guid id, string? name, DateTime expirationDate, ObjectTypeEnum type, decimal price, int amount)
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

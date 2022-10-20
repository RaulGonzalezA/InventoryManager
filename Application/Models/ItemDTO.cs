using InventoryManagerAPI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagerAPI.Application.Models
{
	/// <summary>
	/// Item Model
	/// </summary>
	public class ItemDTO
	{

		/// <summary>
		/// Name of the item
		/// </summary>
		public string? Name { get;  set; }
		/// <summary>
		/// Date expiration of the item
		/// </summary>
		public DateTime ExpirationDate { get;  set; }
		/// <summary>
		/// Type of item
		/// </summary>
		public ObjectTypeEnum Type { get;  set; }
		/// <summary>
		/// Price of the item
		/// </summary>
		public decimal Price { get;  set; }
		/// <summary>
		/// Amount of items
		/// </summary>
		public int Amount { get;  set; }
	}
}

using InventoryManagerAPI.Domain;
using InventoryManagerAPI.Domain.Entities;
using InventoryManagerAPI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagerAPI.Tests.Common.Builders.Entities
{
	/// <summary>
	/// Item builder for testing
	/// </summary>
	public class ItemBuilder
	{
		private Guid _id = Guid.NewGuid();
		private string _name = "BhBike";
		private DateTime _expirationDate = DateTime.Now.AddDays(6);
		private ObjectTypeEnum _type = ObjectTypeEnum.Bike;
		private decimal _price = 100;
		private int _amount = 1;

		/// <summary>
		/// Builds a new item
		/// </summary>
		/// <returns></returns>
		public Item Build()
		{
			return new Item(_id, _name, _expirationDate, _type, _price, _amount);
		}

		/// <summary>
		/// Item builder seting Id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public ItemBuilder WithId(Guid id)
		{
			_id = id;
			return this;
		}

		/// <summary>
		/// Item builder setting Name
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public ItemBuilder WithName(string name)
		{
			_name = name;
			return this;
		}

		/// <summary>
		/// Item builder setting Expiration Date
		/// </summary>
		/// <param name="expirationDate"></param>
		/// <returns></returns>
		public ItemBuilder WithExpirationDate(DateTime expirationDate)
		{
			_expirationDate = expirationDate;
			return this;
		}
	}
}

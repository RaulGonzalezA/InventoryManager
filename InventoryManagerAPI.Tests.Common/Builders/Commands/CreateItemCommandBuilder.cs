using InventoryManagerAPI.Application.Commands;
using InventoryManagerAPI.Domain.Enums;

namespace InventoryManagerAPI.Tests.Common.Builders.Commands
{
	public class CreateItemCommandBuilder
	{
		private string _name = "BhBike";
		private DateTime _expirationDate = DateTime.Now.AddDays(6);
		private ObjectTypeEnum _type = ObjectTypeEnum.Bike;
		private decimal _price = 100;
		private int _amount = 1;

		/// <summary>
		/// Builds a new CreateItemCommand
		/// </summary>
		/// <returns></returns>
		public CreateItemCommand Build()
		{
			return new CreateItemCommand(_name, _type, _price, _amount);
		}

		/// <summary>
		/// CreateItemCommand builder setting Name
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public CreateItemCommandBuilder WithName(string name)
		{
			_name = name;
			return this;
		}

		/// <summary>
		/// CreateItemCommand builder setting Expiration Date
		/// </summary>
		/// <param name="expirationDate"></param>
		/// <returns></returns>
		public CreateItemCommandBuilder WithExpirationDate(DateTime expirationDate)
		{
			_expirationDate = expirationDate;
			return this;
		}
	}
}

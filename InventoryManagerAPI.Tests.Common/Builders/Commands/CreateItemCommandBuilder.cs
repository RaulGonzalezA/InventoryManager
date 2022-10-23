using InventoryManagerAPI.Application.Commands;
using InventoryManagerAPI.Domain.Enums;

namespace InventoryManagerAPI.Tests.Common.Builders.Commands
{
	public class CreateItemCommandBuilder
	{
		internal string _name = "BhBike";
		internal ObjectTypeEnum _type = ObjectTypeEnum.Bike;
		internal decimal _price = 100;
		internal int _amount = 1;

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

		
	}
}

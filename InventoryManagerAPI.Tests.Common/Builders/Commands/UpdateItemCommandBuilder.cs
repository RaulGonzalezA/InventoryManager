using InventoryManagerAPI.Application.Commands;

namespace InventoryManagerAPI.Tests.Common.Builders.Commands
{
	public class UpdateItemCommandBuilder : CreateItemCommandBuilder
	{
		private DateTime _expirationDate = DateTime.Now.AddDays(-1);

		/// <summary>
		/// Builds a new CreateItemCommand
		/// </summary>
		/// <returns></returns>
		public new UpdateItemCommand Build()
		{
			return new UpdateItemCommand(_name, _type, _price, _amount, _expirationDate);
		}

		/// <summary>
		/// UpdateItemCommand builder setting Expiration Date
		/// </summary>
		/// <param name="expirationDate"></param>
		/// <returns></returns>
		public UpdateItemCommandBuilder WithExpirationDate(DateTime expirationDate)
		{
			_expirationDate = expirationDate;
			return this;
		}
	}
}

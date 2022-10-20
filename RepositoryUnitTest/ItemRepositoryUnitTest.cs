

using FluentAssertions;
using InventoryManagerAPI.Tests.Common.Builders.Entities;

namespace InventoryManagerAPI.Repository.UnitTest
{
	public class Tests
	{
		private readonly IItemRepository _repository;

		public Tests()
		{
			_repository = new ItemRepository();
		}

		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public async Task AddItem_WithData_ShouldWork()
		{
			//Arrange
			var item = new ItemBuilder().Build();

			//Act
			var itemResult = await _repository.AddAsync(item);

			//Assert
			itemResult.Should().BeEquivalentTo(item);
		}
	}
}
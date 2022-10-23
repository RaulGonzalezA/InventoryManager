using FluentAssertions;
using Infrastructure;
using Infrastructure.Queries;
using InventoryManagerAPI.Tests.Common.Builders.Entities;
using InventoryManagerAPI.Tests.Common.Context;
using MediatR;
using Moq;

namespace InventoryManagerAPI.Infrastructure.UnitTest
{
	public class ItemQueriesUnitTest
	{
		private IGetItemByName _itemQueries;
		private IItemRepository _repository;
		private ApiDbContext _context;
		private Mock<IPublisher> _publisher;

		[SetUp]
		public void Setup()
		{
			_publisher = new Mock<IPublisher>();
			_context = InMemoryContext.GetContext(_publisher);
			_itemQueries = new GetItemByName(_context);
			_repository = new ItemRepository(_context);
		}

		[Test]
		public async Task GetItemByName_WithName_ShouldReturnItem()
		{
			//Arrange
			var item = new ItemBuilder().Build();
			var item2 = new ItemBuilder().WithId(Guid.NewGuid()).WithName("BhBike2").Build();
			await _repository.AddAsync(item);
			await _repository.AddAsync(item2);

			//Act
			var itemResult = await _itemQueries.GetItemByNameQuery(item.Name);

			//Assert
			itemResult.Should().BeEquivalentTo(item);
		}

		[Test]
		public async Task GetItemByName_WithNameNotExist_ShouldReturnNull()
		{
			//Arrange
			var item = new ItemBuilder().Build();
			var item2 = new ItemBuilder().WithId(Guid.NewGuid()).WithName("BhBike2").Build();
			await _repository.AddAsync(item);
			await _repository.AddAsync(item2);

			//Act
			var itemResult = await _itemQueries.GetItemByNameQuery("NameNotFound");

			//Assert
			itemResult.Should().BeNull();
		}
	}
}

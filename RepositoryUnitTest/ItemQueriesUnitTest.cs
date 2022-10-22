using FluentAssertions;
using Infrastructure;
using Infrastructure.Queries;
using InventoryManagerAPI.Tests.Common.Builders.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

namespace InventoryManagerAPI.Infrastructure.UnitTest
{
	public class ItemQueriesUnitTest
	{
		private readonly IItemQueries _itemQueries;
		private readonly IItemRepository _repository;
		private readonly ApiDbContext _context;
		private readonly DbContextOptions<ApiDbContext> options;
		private readonly IPublisher publisher;
		private readonly Mock<ILogger<ApiDbContext>> _logger;
		public ItemQueriesUnitTest()
		{
			_logger = new Mock<ILogger<ApiDbContext>>();
			_context = new ApiDbContext(options, publisher, _logger.Object);
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

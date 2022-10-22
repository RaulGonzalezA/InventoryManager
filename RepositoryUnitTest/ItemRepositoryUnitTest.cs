

using FluentAssertions;
using Infrastructure;
using InventoryManagerAPI.Tests.Common.Builders.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

namespace InventoryManagerAPI.Repository.UnitTest
{
	public class Tests
	{
		private readonly IItemRepository _repository;
		private readonly ApiDbContext _context;
		private readonly DbContextOptions<ApiDbContext> options;
		private readonly IPublisher publisher;
		private readonly Mock<ILogger<ApiDbContext>> _logger;

		public Tests()
		{
			_logger = new Mock<ILogger<ApiDbContext>>();
			_context = new ApiDbContext(options, publisher, _logger.Object);
			_repository = new ItemRepository(_context);
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

		[Test]
		public async Task AddItem_DuplicatedWithData_ShouldThrowException()
		{
			//Arrange
			var item = new ItemBuilder().Build();

			//Act
			var itemResult = await _repository.AddAsync(item);
			Func<Task> addItemDuplicated = async () => await _repository.AddAsync(item);

			//Assert
			await addItemDuplicated.Should().ThrowAsync<ArgumentException>();
		}

		[Test]
		public async Task DeleteItem_ItemExists_ShouldReturnTrue()
		{
			//Arrange
			var item = new ItemBuilder().Build();
			var itemAdded = await _repository.AddAsync(item);

			//Act
			var result = await _repository.RemoveItemAsync(itemAdded);

			//Assert
			result.Should().BeTrue();
		}

		[Test]
		public void DeleteItem_ItemNotExists_ShouldThrowException()
		{
			//Arrange
			var item = new ItemBuilder().Build();

			//Act
			Func<Task> deleteItemNotExist = async () => await _repository.RemoveItemAsync(item);

			//Assert
			deleteItemNotExist.Should().ThrowAsync<ArgumentException>();
		}

		[Test]
		public async Task AddTwoDiferentItems_WithData_ShouldWork()
		{
			//Arrange
			var item = new ItemBuilder().Build();
			var item2 = new ItemBuilder().WithId(Guid.NewGuid()).WithName("BhBike2").Build();

			//Act
			var itemResult = await _repository.AddAsync(item);
			var itemResult2 = await _repository.AddAsync(item2);

			//Assert
			itemResult.Should().BeEquivalentTo(item);
			itemResult2.Should().BeEquivalentTo(item2);
		}
	}
}
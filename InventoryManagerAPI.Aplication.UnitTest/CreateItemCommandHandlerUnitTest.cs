using FluentAssertions;
using InventoryManagerAPI.Application.Commands;
using InventoryManagerAPI.Domain.Entities;
using InventoryManagerAPI.Domain.Interfaces;
using InventoryManagerAPI.Tests.Common.Builders.Commands;
using InventoryManagerAPI.Tests.Common.Builders.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework.Internal;

namespace InventoryManagerAPI.Aplication.UnitTest
{
	public class CreateItemCommandHandlerUnitTest
	{
		private Mock<IItemRepository> _itemRepository;
		private Mock<ILogger<CreateItemCommandHandler>> _logger;
		private CreateItemCommandHandler _createItemCommandHandler;
		private readonly CancellationToken _cancellationToken = new CancellationToken();

		[SetUp]
		public void Setup()
		{
			_itemRepository = new Mock<IItemRepository>();
			_logger = new Mock<ILogger<CreateItemCommandHandler>>();

			_createItemCommandHandler = new CreateItemCommandHandler(_itemRepository.Object, _logger.Object);
		}

		[Test]
		public async Task Handle_withData_ShouldReturnCreated()
		{
			//Arrange
			var createItem = new CreateItemCommandBuilder().Build();
			var itemResponse = new ItemBuilder().Build();
			_itemRepository.Setup(x => x.AddAsync(It.IsAny<Item>())).ReturnsAsync(itemResponse);

			//Act
			var result = await _createItemCommandHandler.Handle(createItem, _cancellationToken);
			CreatedResult createdResult = (CreatedResult)result;

			//Assert
			result.Should().BeOfType(typeof(CreatedResult));
			result.Should().NotBeNull();
			createdResult.Value.Should().NotBeNull();
			createdResult.Value.Should().BeEquivalentTo(itemResponse);
			_itemRepository.Verify(x => x.AddAsync(It.IsAny<Item>()), Times.Once);
		}

		[Test]
		public async Task Handle_withInvalidData_ShouldReturnBadReques()
		{
			//Arrange
			var createItem = new CreateItemCommandBuilder().WithName("").Build();

			//Act
			var result = await _createItemCommandHandler.Handle(createItem, _cancellationToken);
			BadRequestObjectResult badRequestResult = (BadRequestObjectResult)result;

			//Assert
			result.Should().BeOfType(typeof(BadRequestObjectResult));
			result.Should().NotBeNull();
			badRequestResult.Value.Should().NotBeNull();
			_itemRepository.Verify(x => x.AddAsync(It.IsAny<Item>()), Times.Never);
			_logger.Verify(x => x.Log(LogLevel.Error, It.IsAny<EventId>(), It.IsAny<It.IsAnyType>(), It.IsAny<Exception>(), (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()), Times.Once);
		}

		[Test]
		public async Task Handle_AddAsyncThrowsException_ShouldReturnBadReques()
		{
			//Arrange
			var createItem = new CreateItemCommandBuilder().Build();
			_itemRepository.Setup(x => x.AddAsync(It.IsAny<Item>())).ThrowsAsync(new Exception());

			//Act
			var result = await _createItemCommandHandler.Handle(createItem, _cancellationToken);
			BadRequestObjectResult badRequestResult = (BadRequestObjectResult)result;

			//Assert
			result.Should().BeOfType(typeof(BadRequestObjectResult));
			result.Should().NotBeNull();
			badRequestResult.Value.Should().NotBeNull();
			_itemRepository.Verify(x => x.AddAsync(It.IsAny<Item>()), Times.Once);
			_logger.Verify(x => x.Log(LogLevel.Error, It.IsAny<EventId>(), It.IsAny<It.IsAnyType>(), It.IsAny<Exception>(), (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()), Times.Once);
		}
	}
}

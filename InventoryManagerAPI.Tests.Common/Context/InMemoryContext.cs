using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;

namespace InventoryManagerAPI.Tests.Common.Context
{
	public static class InMemoryContext
	{
		public static ApiDbContext GetContext(Mock<IPublisher> publisher)
		{
			var serviceProvider = new ServiceCollection()
				.AddLogging()
				.BuildServiceProvider();

			var factory = serviceProvider.GetService<ILoggerFactory>();

			var logger = factory.CreateLogger<ApiDbContext>();

			publisher.Setup(x => x.Publish(It.IsAny<string>(), It.IsAny<CancellationToken>()));

			var options = new DbContextOptionsBuilder<ApiDbContext>().UseInMemoryDatabase(databaseName: nameof(ApiDbContext)).Options;

			return new ApiDbContext(options, publisher.Object, logger);
		}
	}
}

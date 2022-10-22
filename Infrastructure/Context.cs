using InventoryManagerAPI.Domain.Entities;
using InventoryManagerAPI.Domain.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure
{
	/// <summary>
	/// Context of the aplication
	/// </summary>
	public class ApiDbContext : DbContext
	{
		private readonly IPublisher _publisher;
		private readonly ILogger<ApiDbContext> _logger;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="options"></param>
		/// <param name="publisher"></param>
		/// <param name="logger"></param>
		public ApiDbContext(DbContextOptions<ApiDbContext> options, IPublisher publisher, ILogger<ApiDbContext> logger) : base(options)
		{
			_publisher = publisher;
			_logger = logger;
		}


		/// <summary>
		/// Table of items
		/// </summary>
		public DbSet<Item> Items => Set<Item>();

		/// <summary>
		/// Table of Users
		/// </summary>
		public DbSet<User> Users => Set<User>();

		/// <summary>
		/// Save Changes Async
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			var result = await base.SaveChangesAsync(cancellationToken);

			var events = ChangeTracker.Entries<IHasDomainEvent>()
					.Select(x => x.Entity.DomainEvents)
					.SelectMany(x => x)
					.Where(domainEvent => !domainEvent.IsPublished)
					.ToArray();

			foreach (var @event in events)
			{
				@event.IsPublished = true;

				_logger.LogInformation("New domain event {Event}", @event.GetType().Name);

				await _publisher.Publish(@event);
			}

			return result;
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<Item>()
				.Ignore(x => x.DomainEvents);
		}

	}
}

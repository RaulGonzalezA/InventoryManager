using MediatR;

namespace InventoryManagerAPI.Domain.Events
{
	/// <summary>
	/// Base Event
	/// </summary>
	public abstract class DomainEvent : INotification
	{
		protected DomainEvent()
		{
			DateOccurred = DateTimeOffset.UtcNow;
		}
		/// <summary>
		/// If the event is Published
		/// </summary>
		public bool IsPublished { get; set; }
		/// <summary>
		/// Date of publishing
		/// </summary>
		public DateTimeOffset DateOccurred { get; protected set; } = DateTime.UtcNow;
	}
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
		public bool IsPublished { get; set; }
		public DateTimeOffset DateOccurred { get; protected set; } = DateTime.UtcNow;
	}
}

namespace InventoryManagerAPI.Domain.Events
{
	/// <summary>
	/// Interface Has Domain Events
	/// </summary>
	public interface IHasDomainEvent
	{
		public List<DomainEvent> DomainEvents { get; set; }
	}
}

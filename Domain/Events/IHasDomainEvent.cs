namespace InventoryManagerAPI.Domain.Events
{
	public interface IHasDomainEvent
	{
		public List<DomainEvent> DomainEvents { get; set; }
	}
}

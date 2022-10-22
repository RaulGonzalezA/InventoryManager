using InventoryManagerAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagerAPI.Domain.Events
{
	public class ItemRemovedEvent : DomainEvent
	{
		public ItemRemovedEvent(Item item)
		{
			Item = item;
		}

		public Item Item { get; set; }
	}
}

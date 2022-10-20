using FluentAssertions;
using InventoryManagerAPI.Tests.Common.Builders.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagerAPI.Infrastructure.UnitTest
{
	public class ItemQueriesUnitTest
	{
		private readonly IItemQueries _itemQueries;
		private readonly IItemRepository _repository;

		public ItemQueriesUnitTest()
		{
			_itemQueries = new ItemQueries();
			_repository = new ItemRepository();
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
			var itemResult = await _itemQueries.GetItemByName(item.Name);

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
			var itemResult = await _itemQueries.GetItemByName("NameNotFound");

			//Assert
			itemResult.Should().BeNull();
		}
	}
}

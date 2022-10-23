using FluentAssertions;
using InventoryManagerAPI.Application.Services;
using InventoryManagerAPI.Domain.Entities;
using InventoryManagerAPI.Domain.Interfaces;
using Moq;

namespace InventoryManagerAPI.Aplication.UnitTest
{
	public class UserServiceUnitTest
	{
		private Mock<IUserQueries> _userQueries;
		private UserService _userService;

		[SetUp]
		public void Setup()
		{
			_userQueries = new Mock<IUserQueries>();

			_userService = new UserService(_userQueries.Object);
		}

		[Test]
		public async Task IdentifyUser_WithData_ShouldWork()
		{
			//Arrange
			string name = "Raul";
			string pass = "1234";

			_userQueries.Setup(x => x.IdentifyUserQuery(name, pass)).ReturnsAsync(new User(name, pass));

			//Act
			var result = await _userService.IdentifyUser(name, pass);

			//Assert
			result.Should().BeTrue();
		}

		[Test]
		public async Task IdentifyUser_WithWrongData_ShouldReturnFalse()
		{
			//Arrange
			string name = "Raul";
			string pass = "1234";

			_userQueries.Setup(x => x.IdentifyUserQuery(name, pass)).ReturnsAsync(value: null);

			//Act
			var result = await _userService.IdentifyUser(name, pass);

			//Assert
			result.Should().BeFalse();
		}
	}
}
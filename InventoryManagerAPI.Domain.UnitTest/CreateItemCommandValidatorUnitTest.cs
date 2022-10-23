using FluentAssertions;
using InventoryManagerAPI.Application.Commands;
using InventoryManagerAPI.Application.Validators;
using InventoryManagerAPI.Tests.Common.Builders.Commands;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace InventoryManagerAPI.Domain.UnitTest
{
	public class CreateItemCommandValidatorUnitTest
	{

		[Test]
		public void ValidateItem_ValidData_ShouldBeValid()
		{
			//Arrange
			CreateItemCommand item = new CreateItemCommandBuilder().Build();
			CreateItemFluentValidator validator = new CreateItemFluentValidator();

			//Act
			ValidationResult results = validator.Validate(item);

			//Assert
			results.IsValid.Should().BeTrue();
		}

		[Test]
		public void ValidateItem_WrongDate_ShouldBeValid()
		{
			//Arrange
			CreateItemCommand item = new CreateItemCommandBuilder().WithExpirationDate(DateTime.Now).Build();
			CreateItemFluentValidator validator = new CreateItemFluentValidator();

			//Act
			ValidationResult results = validator.Validate(item);

			//Assert
			results.IsValid.Should().BeFalse();
			results.Errors.Count.Should().Be(1);
		}
	}
}
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
		public void ValidateItem_WithoutName_ShouldBeNoValid()
		{
			//Arrange
			CreateItemCommand item = new CreateItemCommandBuilder().WithName(String.Empty).Build();
			CreateItemFluentValidator validator = new CreateItemFluentValidator();

			//Act
			ValidationResult results = validator.Validate(item);

			//Assert
			results.IsValid.Should().BeFalse();
			results.Errors.Count.Should().Be(1);
		}
	}
}
using FluentAssertions;
using FluentValidation.Results;
using InventoryManagerAPI.Application.Commands;
using InventoryManagerAPI.Application.Validators;
using InventoryManagerAPI.Tests.Common.Builders.Commands;

namespace InventoryManagerAPI.Domain.UnitTest
{
	public class UpdateItemCommandValidatorUnitTest
	{
		[Test]
		public void ValidateItem_ValidData_ShouldBeValid()
		{
			//Arrange
			UpdateItemCommand item = new UpdateItemCommandBuilder().Build();
			UpdateItemFluentValidator validator = new UpdateItemFluentValidator();

			//Act
			ValidationResult results = validator.Validate(item);

			//Assert
			results.IsValid.Should().BeTrue();
		}

		[Test]
		public void ValidateItem_WithoutName_ShouldBeNoValid()
		{
			//Arrange
			UpdateItemCommand item = new UpdateItemCommandBuilder().WithExpirationDate(DateTime.Today.AddDays(1)).Build();
			UpdateItemFluentValidator validator = new UpdateItemFluentValidator();

			//Act
			ValidationResult results = validator.Validate(item);

			//Assert
			results.IsValid.Should().BeFalse();
			results.Errors.Count.Should().Be(1);
		}
	}
}

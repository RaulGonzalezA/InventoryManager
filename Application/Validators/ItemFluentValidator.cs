﻿using FluentValidation;
using InventoryManagerAPI.Application.Commands;
using InventoryManagerAPI.Domain.Entities.Models;

namespace InventoryManagerAPI.Application.Validators
{
	/// <summary>
	/// Item Fluent Validator
	/// </summary>
	public class ItemFluentValidator : AbstractValidator<CreateItemCommand>
	{
		/// <summary>
		/// Constructor to set rules of validation
		/// </summary>
		public ItemFluentValidator()
		{
			RuleFor(p => p.Name)
				.NotEmpty()
				.NotNull()
				.WithErrorCode("ItemName")
				.WithMessage("Name is mandatory");

			RuleFor(p => p.Price)
				.NotNull()
				.WithErrorCode("ItemPrice")
				.WithMessage("Price is mandatory");

			RuleFor(p => p.Price)
				.Must(p => true).GreaterThan(0)
				.WithErrorCode("ItemPrice")
				.WithMessage("Price Should be greater than 0");

			RuleFor(p => p.Amount)
				.NotNull()
				.WithErrorCode("ItemAmount")
				.WithMessage("Amount is mandatory");

			RuleFor(p => p.Amount)
				.Must(p => true).GreaterThan(0)
				.WithErrorCode("ItemAmount")
				.WithMessage("Amount Should be greater than 0");

			RuleFor(p => p.ExpirationDate)
				.NotNull()
				.WithErrorCode("ItemExpirationDate")
				.WithMessage("Expiration Date is mandatory");

			RuleFor(p => p.ExpirationDate)
				.Must(p => true).GreaterThan(DateTime.Now.AddDays(5))
				.WithErrorCode("ItemExpirationDate")
				.WithMessage("Expiration Date should be at least 5 days from today");
		}
	}
}
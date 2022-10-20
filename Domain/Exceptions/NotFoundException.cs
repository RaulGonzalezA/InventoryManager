﻿namespace InventoryManagerAPI.Domain.Exceptions
{
	/// <summary>
	/// Exception when a object is not found
	/// </summary>
	public class NotFoundException : Exception
	{
		public NotFoundException()
		{
		}

		public NotFoundException(string? message) : base(message)
		{
		}

		public NotFoundException(string? message, Exception? innerException) : base(message, innerException)
		{
		}
	}
}

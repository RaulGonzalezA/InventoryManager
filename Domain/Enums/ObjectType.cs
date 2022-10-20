using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace InventoryManagerAPI.Domain.Enums
{
	/// <summary>
	/// Enum for the diferent Object Types
	/// </summary>
	[JsonConverter(typeof(StringEnumConverter))]
	public enum ObjectTypeEnum
	{
		/// <summary>
		/// Bike
		/// </summary>
		[EnumMember(Value = "Bike")]
		Bike,
		/// <summary>
		/// Toy car
		/// </summary>
		[EnumMember(Value = "Car")]
		Car,
		/// <summary>
		/// Video games
		/// </summary>
		[EnumMember(Value = "Videogame")]
		Videogame,
		/// <summary>
		/// Table games
		/// </summary>
		[EnumMember(Value = "Tablegame")]
		Tablegame
	}
}

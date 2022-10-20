using InventoryManagerAPI.Domain;

namespace InventoryManagerAPI.Application.Interfaces
{
	public interface IUserService
	{
		public Task<bool> IdentifyUser(string userName, string password);
	}
}

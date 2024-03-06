namespace HouseRentingSystem.Core.Contracts
{
    public interface IAgentService
    {
        Task<bool> ExistsByIdAsync(string userId);
        Task<bool> UserWithPhoneExistsAsync(string phoneNumber);
        Task<bool> UserHasRentsAsync(string userId);
        Task CreateAsync(string userId, string phoneNumber);
        Task<int?> GetAgentIdAsync(string userId);
    }
}

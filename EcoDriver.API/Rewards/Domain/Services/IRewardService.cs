using EcoDriver.API.Rewards.Domain.Models;
using EcoDriver.API.Rewards.Domain.Services.Communication;

namespace EcoDriver.API.Rewards.Domain.Services;

public interface IRewardService
{
    Task<IEnumerable<Reward>> ListAsync();
    Task<RewardResponse> SaveAsync(Reward reward);
    Task<RewardResponse> UpdateAsync(int id, Reward reward);
    Task<RewardResponse> DeleteAsync(int id);
}
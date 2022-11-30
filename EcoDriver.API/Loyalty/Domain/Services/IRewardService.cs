using EcoDriver.API.Loyalty.Domain.Models;
using EcoDriver.API.Loyalty.Domain.Services.Communication;

namespace EcoDriver.API.Loyalty.Domain.Services;

public interface IRewardService
{
    Task<IEnumerable<Reward>> ListAsync();
    Task<RewardResponse> SaveAsync(Reward reward);
    Task<RewardResponse> UpdateAsync(int id, Reward reward);
    Task<RewardResponse> DeleteAsync(int id);
    Task<RewardResponse> SaveRewardFromFleetIdAsync(int fleetId, Reward reward);
    Task<IEnumerable<Reward>> ListByScoreMajorThanAsync(int score);
}
using EcoDriver.API.Rewards.Domain.Models;

namespace EcoDriver.API.Rewards.Domain.Repositories;

public interface IRewardRepository
{
    Task<IEnumerable<Reward>> ListAsync();
    Task AddAsync(Reward reward);
    Task<Reward> FindByIdAsync(int id);
    void Update(Reward reward);
    void Remove(Reward reward);
    
    Task<IEnumerable<Reward>> FindByMajorScoreAsync(float majorScore);
    Task<Reward> FindByNameAsync(string name);

}
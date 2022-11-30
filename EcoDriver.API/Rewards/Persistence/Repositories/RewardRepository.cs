using EcoDriver.API.Rewards.Domain.Models;
using EcoDriver.API.Rewards.Domain.Repositories;
using EcoDriver.API.Shared.Persistence.Context;
using EcoDriver.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EcoDriver.API.Rewards.Persistence.Repositories;

public class RewardRepository : BaseRepository,IRewardRepository
{
    public RewardRepository(AppDbContext context) : base(context)
    {
    }
    public async Task<IEnumerable<Reward>> ListAsync()
    {
        return await _Context.Rewards.ToListAsync();
    }

    public async Task AddAsync(Reward reward)
    {
        await _Context.Rewards.AddAsync(reward);
    }

    public async Task<Reward> FindByIdAsync(int id)
    {
        return await _Context.Rewards.FindAsync(id);
    }

    public void Update(Reward reward)
    {
        _Context.Rewards.Update(reward);
    }

    public void Remove(Reward reward)
    {
        _Context.Rewards.Remove(reward);
    }

    public async Task<IEnumerable<Reward>> FindByMajorScoreAsync(float majorScore)
    {
        return await _Context.Rewards.Where(r => r.Score >= majorScore).ToListAsync();
    }

    public async Task<Reward> FindByNameAsync(string name)
    {
        return await _Context.Rewards.FirstOrDefaultAsync(r => r.Name == name);
    }
}
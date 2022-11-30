using EcoDriver.API.Loyalty.Domain.Models;
using EcoDriver.API.Loyalty.Domain.Repositories;
using EcoDriver.API.Loyalty.Domain.Services;
using EcoDriver.API.Loyalty.Domain.Services.Communication;
using EcoDriver.API.Shared.Domain.Repositories;

namespace EcoDriver.API.Loyalty.Services;

public class RewardService : IRewardService
{
    private readonly IRewardRepository _rewardRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RewardService(IRewardRepository rewardRepository, IUnitOfWork unitOfWork)
    {
        _rewardRepository = rewardRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Reward>> ListAsync()
    {
        return await  _rewardRepository.ListAsync();
    }

    public async Task<RewardResponse> SaveAsync(Reward reward)
    {
        var existingReward = await _rewardRepository.FindByNameAsync(reward.Name);

        if (existingReward != null)
        {
            return new RewardResponse("Reward name already exists.");
        }

        if (reward.Score <= 0)
        {
            return new RewardResponse("Score must be greater than zero.");
        }

        try
        {
            await _rewardRepository.AddAsync(reward);
            await _unitOfWork.CompleteAsync();

            return new RewardResponse(reward);
        }
        catch (Exception ex)
        {
            return new RewardResponse($"An error occurred when saving the reward: {ex.Message}");
        }
    }

    public async Task<RewardResponse> UpdateAsync(int id, Reward reward)
    {
        var existingReward = await _rewardRepository.FindByIdAsync(id);

        if (existingReward == null)
        {
            return new RewardResponse("Reward not found.");
        }

        existingReward.Name = reward.Name;
        existingReward.Score = reward.Score;

        try
        {
            _rewardRepository.Update(existingReward);
            await _unitOfWork.CompleteAsync();

            return new RewardResponse(existingReward);
        }
        catch (Exception ex)
        {
            return new RewardResponse($"An error occurred when updating the reward: {ex.Message}");
        }
    }

    public async Task<RewardResponse> DeleteAsync(int id)
    {
        var existingReward = await _rewardRepository.FindByIdAsync(id);

        if (existingReward == null)
        {
            return new RewardResponse("Reward not found.");
        }

        try
        {
            _rewardRepository.Remove(existingReward);
            await _unitOfWork.CompleteAsync();

            return new RewardResponse(existingReward);
        }
        catch (Exception ex)
        {
            return new RewardResponse($"An error occurred when deleting the reward: {ex.Message}");
        }
    }

    public async Task<RewardResponse> SaveRewardFromFleetIdAsync(int fleetId, Reward reward)
    {
        var existingReward = await _rewardRepository.FindByNameAsync(reward.Name);

        if (existingReward != null)
        {
            return new RewardResponse("Reward name already exists.");
        }

        if (reward.Score <= 0)
        {
            return new RewardResponse("Score must be greater than zero.");
        }
        

        try
        {
            await _rewardRepository.AddAsync(reward);
            await _unitOfWork.CompleteAsync();

            return new RewardResponse(reward);
        }
        catch (Exception ex)
        {
            return new RewardResponse($"An error occurred when saving the reward: {ex.Message}");
        }
    }

    public async Task<IEnumerable<Reward>> ListByScoreMajorThanAsync(int score)
    {
        return await  _rewardRepository.FindByMajorScoreAsync(score);
    }
}
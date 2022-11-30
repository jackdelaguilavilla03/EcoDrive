using EcoDriver.API.Rewards.Domain.Models;
using EcoDriver.API.Shared.Services.Communication;

namespace EcoDriver.API.Rewards.Domain.Services.Communication;

public class RewardResponse : BaseResponse<Reward>
{
    public RewardResponse(string message) : base(message)
    {
    }

    public RewardResponse(Reward resource) : base(resource)
    {
    }
}
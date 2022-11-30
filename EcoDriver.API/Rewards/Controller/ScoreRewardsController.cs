using System.Net.Mime;
using AutoMapper;
using EcoDriver.API.Rewards.Domain.Models;
using EcoDriver.API.Rewards.Domain.Services;
using EcoDriver.API.Rewards.Resources;
using Microsoft.AspNetCore.Mvc;

namespace EcoDriver.API.Rewards.Controller;

[ApiController]
[Route("api/v1/scores/{score}/reward")]
[Produces(MediaTypeNames.Application.Json)]
public class ScoreRewardsController : ControllerBase
{
    private readonly IRewardService _rewardService;
    private readonly IMapper _mapper;
    
    public ScoreRewardsController (IRewardService rewardService, IMapper mapper)
    {
        _rewardService = rewardService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<RewardResource>> GetByScoreMajorThanAsync(int score)
    {
        var rewards = await _rewardService.ListByScoreMajorThanAsync(score);
        var resources = _mapper.Map<IEnumerable<Reward>, IEnumerable<RewardResource>>(rewards);
        return resources;
    }

}
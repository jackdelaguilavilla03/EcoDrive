using System.Net.Mime;
using AutoMapper;
using EcoDriver.API.Loyalty.Domain.Models;
using EcoDriver.API.Loyalty.Domain.Services;
using EcoDriver.API.Loyalty.Resources;
using Microsoft.AspNetCore.Mvc;

namespace EcoDriver.API.Loyalty.Controller;

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
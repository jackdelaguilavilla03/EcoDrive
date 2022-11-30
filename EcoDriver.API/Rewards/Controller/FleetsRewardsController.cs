using System.Net.Mime;
using AutoMapper;
using EcoDriver.API.Rewards.Domain.Models;
using EcoDriver.API.Rewards.Domain.Services;
using EcoDriver.API.Rewards.Resources;
using EcoDriver.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EcoDriver.API.Rewards.Controller;

[ApiController]
[Route("api/v1/fleets/{fleetId}/reward")]
[Produces(MediaTypeNames.Application.Json)]
public class FleetsRewardsController : ControllerBase
{
    private readonly IRewardService _rewardService;
    private readonly IMapper _mapper;
    
    public FleetsRewardsController(IRewardService rewardService, IMapper mapper)
    {
        _rewardService = rewardService;
        _mapper = mapper;
    }
    
    
    // Register a new reward with the fleetid from the route
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromRoute] int fleetId, [FromBody] SaveRewardResource rewardRequest)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var reward = _mapper.Map<SaveRewardResource, Reward>(rewardRequest);
        var result = await _rewardService.SaveRewardFromFleetIdAsync(fleetId, reward);
    
        if (!result.Success)
            return BadRequest(result.Message);
    
        var rewardResource = _mapper.Map<Reward, RewardResource>(result.Resource);
        return Created(nameof(PostAsync), rewardResource);
    }

}
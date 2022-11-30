using System.Net.Mime;
using AutoMapper;
using EcoDriver.API.Loyalty.Domain.Models;
using EcoDriver.API.Loyalty.Domain.Services;
using EcoDriver.API.Loyalty.Resources;
using EcoDriver.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EcoDriver.API.Loyalty.Controller;

[ApiController]
[Route("api/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Create, read, update, and delete operations for loyalty programs.")]
public class RewardsController : ControllerBase
{
    private readonly IRewardService _rewardService;
    private readonly IMapper _mapper;
    
    public RewardsController(IRewardService rewardService, IMapper mapper)
    {
        _rewardService = rewardService;
        _mapper = mapper;
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<RewardResource>),200)]
    public async Task<IEnumerable<RewardResource>> GetAllAsync()
    {
        var rewards = await _rewardService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Reward>, IEnumerable<RewardResource>>(rewards);
        return resources;
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(RewardResource), 201)]
    [ProducesResponseType(typeof(List<string>), 400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> PostAsync([FromBody] SaveRewardResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
    
        var reward = _mapper.Map<SaveRewardResource, Reward>(resource);
        var result = await _rewardService.SaveAsync(reward);
    
        if (!result.Success)
            return BadRequest(result.Message);
    
        var rewardResource = _mapper.Map<Reward, RewardResource>(result.Resource);
        return Ok(rewardResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveRewardResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
    
        var reward = _mapper.Map<SaveRewardResource, Reward>(resource);
        var result = await _rewardService.UpdateAsync(id, reward);
    
        if (!result.Success)
            return BadRequest(result.Message);
    
        var rewardResource = _mapper.Map<Reward, RewardResource>(result.Resource);
        return Ok(rewardResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _rewardService.DeleteAsync(id);
    
        if (!result.Success)
            return BadRequest(result.Message);
    
        var rewardResource = _mapper.Map<Reward, RewardResource>(result.Resource);
        return Ok(rewardResource);
    }

}
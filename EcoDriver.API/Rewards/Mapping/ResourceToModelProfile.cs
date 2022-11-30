using AutoMapper;
using EcoDriver.API.Rewards.Domain.Models;
using EcoDriver.API.Rewards.Resources;

namespace EcoDriver.API.Rewards.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveRewardResource, Reward>();
    }
}
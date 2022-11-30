using AutoMapper;
using EcoDriver.API.Rewards.Domain.Models;
using EcoDriver.API.Rewards.Resources;

namespace EcoDriver.API.Rewards.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Reward, RewardResource>();
    }
}
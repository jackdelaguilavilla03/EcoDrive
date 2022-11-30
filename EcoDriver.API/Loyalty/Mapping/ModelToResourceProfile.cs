using AutoMapper;
using EcoDriver.API.Loyalty.Domain.Models;
using EcoDriver.API.Loyalty.Resources;

namespace EcoDriver.API.Loyalty.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Reward, RewardResource>();
    }
}
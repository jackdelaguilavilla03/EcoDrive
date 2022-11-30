using System.ComponentModel.DataAnnotations;

namespace EcoDriver.API.Loyalty.Resources;

public class SaveRewardResource
{
    [Required]
    public int FleetId { get; set; }
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    [Required]
    public float Score { get; set; }
}
namespace EcoDriver.API.Rewards.Domain.Models;

public class Reward
{
    public int Id { get; set; }
    public int Fleetid { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public float Score { get; set; }
}
namespace EcoDriver.API.Rewards.Resources;

public class RewardResource
{
    public int Id { get; set; }
    public int Fleetid { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public float Score { get; set; }
}
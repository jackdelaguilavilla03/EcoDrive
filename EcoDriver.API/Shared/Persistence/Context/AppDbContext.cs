using EcoDriver.API.Rewards.Domain.Models;
using EcoDriver.API.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace EcoDriver.API.Shared.Persistence.Context;

public class AppDbContext : DbContext
{
    public DbSet<Reward> Rewards { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<Reward>().ToTable("Rewards");
        builder.Entity<Reward>().HasKey(p => p.Id);
        builder.Entity<Reward>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Reward>().Property(p => p.Fleetid).IsRequired();
        builder.Entity<Reward>().Property(p => p.Name).IsRequired();
        builder.Entity<Reward>().Property(p => p.Description);
        builder.Entity<Reward>().Property(p => p.Score).IsRequired();
        
        builder.useSnakeCaseNamingConvention();
    }
}
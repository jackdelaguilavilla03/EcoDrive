using EcoDriver.API.Shared.Persistence.Context;

namespace EcoDriver.API.Shared.Persistence.Repositories;

public class BaseRepository
{
    public readonly AppDbContext _Context;

    public BaseRepository(AppDbContext context)
    {
        _Context = context;
    }
}
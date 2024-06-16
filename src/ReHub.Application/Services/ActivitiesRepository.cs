using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ReHub.Domain;

namespace ReHub.DbDataModel.Services;

public class ActivitiesRepository : IActivitiesRepository
{
    private readonly DataContext _context;
    private readonly ILogger<ActivitiesRepository> _logger;

    public ActivitiesRepository(DataContext context, ILogger<ActivitiesRepository> logger) 
    {
        _context = context;
        _logger = logger;
    }
    public Task<List<Activity>> List()
    {
        return _context.Activities.ToListAsync<Activity>();
    }
}

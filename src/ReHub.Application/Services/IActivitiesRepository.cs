using ReHub.Domain;

namespace ReHub.DbDataModel.Services;

public interface IActivitiesRepository
{
    Task<List<Activity>> List();
}

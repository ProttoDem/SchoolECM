namespace eShop.Ordering.API.Application.Queries;

public interface IScheduleQueries
{
    Task<ScheduleDetails> GetScheduleAsync(int id);

    Task<IEnumerable<ScheduleSummary>> GetSchedulesFromUserAsync(string userId);
    Task<IEnumerable<DisciplineViewModel>> GetAllDisciplinesFromUserAsync(string userId);
    Task<IEnumerable<GroupViewModel>> GetAllGroupsFromUserAsync(string userId, int disciplineId);
}

namespace eShop.Ordering.Domain.AggregatesModel.SchoolAggregate;

//This is just the RepositoryContracts or Interface defined at the Domain Layer
//as requisite for the Schedules Aggregate

public interface IScheduleRepository : IRepository<Schedule>
{
    Schedule Add(Schedule order);

    /*void Update(Schedule order);*/

    Task<Schedule> GetAsync(int scheduleId);
    Task<List<Schedule>> GetAllAsync(int GroupId);
}

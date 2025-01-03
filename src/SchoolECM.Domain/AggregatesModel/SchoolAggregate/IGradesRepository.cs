namespace eShop.Ordering.Domain.AggregatesModel.SchoolAggregate;

//This is just the RepositoryContracts or Interface defined at the Domain Layer
//as requisite for the Schedules Aggregate

public interface IGradesRepository : IRepository<Grade>
{
    Grade Add(Grade grade);

    void Update(Grade grade);

    Task<List<Grade>> GetAllByStudentIdAndDisciplineIdAsync(int studentId, int disciplineId);
    Task<List<Grade>> GetAllByClassIdAndDisciplineIdAsync(int groupId, int disciplineId);
}

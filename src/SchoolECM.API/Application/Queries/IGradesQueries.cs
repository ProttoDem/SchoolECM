namespace eShop.Ordering.API.Application.Queries;

public interface IGradesQueries
{
    Task<GradesByDisciplineAndGroup> GetGradesByGroupAndDisciplineAsync(string userId, int disciplineId, int groupId);

    Task<GradesByDisciplineAndStudent> GetGradesByStudentAndDisciplineAsync(string userId, int disciplineId);
}

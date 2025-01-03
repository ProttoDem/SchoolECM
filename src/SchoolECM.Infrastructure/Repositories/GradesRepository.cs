using eShop.Ordering.Domain.AggregatesModel.SchoolAggregate;

namespace eShop.Ordering.Infrastructure.Repositories;

public class GradesRepository
    : IGradesRepository
{
    private readonly SchoolECMContext _context;
    public IUnitOfWork UnitOfWork => _context;

    public GradesRepository(SchoolECMContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public Grade Add(Grade grade)
    {
        if (grade.IsTransient())
        {
            return _context.Grades
                .Add(grade)
                .Entity;
        }

        return grade;
    }

    public void Update(Grade grade)
    {
        _context.Grades.Update(grade);
    }

    public async Task<List<Grade>> GetAllByStudentIdAndDisciplineIdAsync(int studentId, int disciplineId)
    {
        return await _context.Grades.Where(s => s.Student.Id == studentId && s.Schedule.Discipline.Id == disciplineId).ToListAsync();
    }

    public async Task<List<Grade>> GetAllByClassIdAndDisciplineIdAsync(int groupId, int disciplineId)
    {
        return await _context.Grades.Where(s => s.Student.Group.Id == groupId && s.Schedule.Discipline.Id == disciplineId).ToListAsync();
    }
}

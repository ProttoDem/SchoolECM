using eShop.Ordering.Domain.AggregatesModel.SchoolAggregate;

namespace eShop.Ordering.API.Application.Queries;

public class GradesQueries(SchoolECMContext context)
    : IGradesQueries
{
    public async Task<GradesByDisciplineAndGroup> GetGradesByGroupAndDisciplineAsync(string userId, int disciplineId, int groupId)
    {
        var schedules = await context.Schedules.Include(s => s.Group).Include(s => s.Discipline).Include(s => s.Teacher).Where(s => s.Group.Id == groupId && s.Discipline.Id == disciplineId && s.Teacher.IdentityGuid == userId).ToListAsync();

        var students = context.Students.Include(s => s.Group).Where(s => s.Group.Id == groupId);

        Dictionary<int, Dictionary<DateTime, int?>> res = new Dictionary<int, Dictionary<DateTime, int?>> { };
        foreach(var student in students)
        {
            var grades = await context.Grades.Include(g => g.Student).Include(g => g.Schedule).Where(g => schedules.Contains(g.Schedule) && g.Student.Id == student.Id).ToListAsync();

            Dictionary<DateTime, int?> d = new Dictionary<DateTime, int?> { };
            foreach (var grade in grades)
            {
                d.Add(new DateTime(grade.Schedule.DisciplineDate, grade.Schedule.DisciplineTime), grade.Value);
            }
            res.Add(student.Id, d);
        }

        return new GradesByDisciplineAndGroup
        {
            GradesByStudent = res
        };
    }

    public async Task<GradesByDisciplineAndStudent> GetGradesByStudentAndDisciplineAsync(string userId, int disciplineId)
    {
        var student = await context.Students.Include(s => s.Group).FirstOrDefaultAsync(s => s.IdentityGuid == userId);
        
        Dictionary<DateTime, int?> gradesByDateTime = new Dictionary<DateTime, int?>();
        if (student is not null)
        {
            var schedules = await context.Schedules.Include(s => s.Group).Where(s => s.Group == student.Group && s.Discipline.Id == disciplineId).ToListAsync();
            foreach (var schedule in schedules)
            {
                var grade = await context.Grades.Include(g => g.Student).Include(g => g.Schedule).FirstOrDefaultAsync(g => g.Schedule == schedule && g.Student == student);
                gradesByDateTime.Add(new DateTime(schedule.DisciplineDate, schedule.DisciplineTime), grade is null ? null : grade.Value);
            }
        }

        var discipline = await context.Disciplines.FirstOrDefaultAsync(d => d.Id == disciplineId);

        var res = new GradesByDisciplineAndStudent { 

            DisciplineName = discipline.DisciplineName,
            GradesByDateTime = gradesByDateTime
        
        };

        return res;
    }

    public async Task<ScheduleDetails> GetScheduleAsync(int id)
    {
        var schedule = await context.Schedules
            .Include(o => o.Discipline)
            .Include(o => o.Teacher)
            .FirstOrDefaultAsync(o => o.Id == id);

        if (schedule is null)
            throw new KeyNotFoundException();

        return new ScheduleDetails
        {
            Id = id,
            DisciplineId = schedule.Discipline.Id,
            DisciplineName = schedule.Discipline.DisciplineName,
            DisciplineDescription = schedule.Discipline.Description,
            Date = schedule.DisciplineDate,
            Time = schedule.DisciplineTime,
            TeacherName = schedule.Teacher.Name + " " + schedule.Teacher.LastName,
            RoomNumber = schedule.RoomNumber
        };
    }

    public async Task<IEnumerable<ScheduleSummary>> GetSchedulesFromUserAsync(string userId)
    {
        var student = context.Students.Include(s => s.Group).FirstOrDefault(s => s.IdentityGuid == userId);
        if (student is not null)
        {
            var groupId = student.Group.Id;

            return await context.Schedules
                .Where(o => o.Group.Id == groupId)
                .Include(o => o.Teacher)
                .Include(o => o.Discipline)
                .Select(o => new ScheduleSummary
                {
                    Id = o.Id,
                    DisciplineName = o.Discipline.DisciplineName,
                    Date = o.DisciplineDate,
                    Time = o.DisciplineTime,
                    TeacherName = o.Teacher.Name + " " + o.Teacher.LastName
                })
                .ToListAsync();

        }
        else
        {
            var teacher = context.Teachers.FirstOrDefault(s => s.IdentityGuid == userId);
            return await context.Schedules
            .Where(o => o.Teacher == teacher)
            .Include(o => o.Discipline)
            .Select(o => new ScheduleSummary
            {
                Id = o.Id,
                DisciplineName = o.Discipline.DisciplineName,
                Date = o.DisciplineDate,
                Time = o.DisciplineTime,
                TeacherName = o.Teacher.Name + " " + o.Teacher.LastName
            })
            .ToListAsync();
        }
    }
}

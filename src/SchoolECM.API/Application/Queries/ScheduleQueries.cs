using static System.Runtime.InteropServices.JavaScript.JSType;

namespace eShop.Ordering.API.Application.Queries;

public class ScheduleQueries(SchoolECMContext context)
    : IScheduleQueries
{
    public async Task<IEnumerable<DisciplineViewModel>> GetAllDisciplinesFromUserAsync(string userId)
    {
        var student = context.Students.Include(s => s.Group).FirstOrDefault(s => s.IdentityGuid == userId);
        if (student is not null)
        {
            var groupId = student.Group.Id;
            List<int> IdsOfDisciplines = new List<int> { };
            var schedules = await context.Schedules.Include(s => s.Group).Include(s => s.Discipline).Where(s => s.Group.Id == groupId).ToListAsync();

            foreach (var schedule in schedules)
            {
                if (!IdsOfDisciplines.Contains(schedule.Discipline.Id))
                {
                    IdsOfDisciplines.Add(schedule.Discipline.Id);
                }
            }

            return await context.Disciplines
                .Where(d => IdsOfDisciplines.Contains(d.Id))
                .Select(o => new DisciplineViewModel
                {
                    Id = o.Id,
                    DisciplineName = o.DisciplineName
                })
                .ToListAsync();

        }
        else
        {
            var teacher = context.Teachers.FirstOrDefault(s => s.IdentityGuid == userId);

            List<int> IdsOfDisciplines = new List<int> { };
            var schedules = await context.Schedules.Include(s => s.Teacher).Include(s => s.Discipline).Where(s => s.Teacher.Id == teacher.Id).ToListAsync();

            foreach (var schedule in schedules)
            {
                if (!IdsOfDisciplines.Contains(schedule.Discipline.Id))
                {
                    IdsOfDisciplines.Add(schedule.Discipline.Id);
                }
            }

            return await context.Disciplines
                .Where(d => IdsOfDisciplines.Contains(d.Id))
                .Select(o => new DisciplineViewModel
                {
                    Id = o.Id,
                    DisciplineName = o.DisciplineName
                })
                .ToListAsync();
        }
    }

    public async Task<IEnumerable<GroupViewModel>> GetAllGroupsFromUserAsync(string userId, int disciplineId)
    {        
        var teacher = context.Teachers.FirstOrDefault(s => s.IdentityGuid == userId);

        List<int> IdsOfGroups = new List<int> { };
        var schedules = await context.Schedules.Include(s => s.Teacher).Include(s => s.Group).Include(s => s.Discipline).Where(s => s.Teacher.Id == teacher.Id).ToListAsync();

        foreach (var schedule in schedules)
        {
            if (!IdsOfGroups.Contains(schedule.Group.Id))
            {
                IdsOfGroups.Add(schedule.Group.Id);
            }
        }

        return await context.Groups
            .Where(d => IdsOfGroups.Contains(d.Id))
            .Select(o => new GroupViewModel
            {
                Id = o.Id,
                GroupName = o.Year + "-" + o.Letter
            })
            .ToListAsync();        
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
        var student = context.Students.Include(s=> s.Group).FirstOrDefault(s => s.IdentityGuid == userId);
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

        } else
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
    
    /*public async Task<IEnumerable<CardType>> GetCardTypesAsync() => 
        await context.CardTypes.Select(c=> new CardType { Id = c.Id, Name = c.Name }).ToListAsync();*/
}

using eShop.Ordering.Domain.AggregatesModel.SchoolAggregate;

namespace eShop.Ordering.Infrastructure.Repositories;

public class ScheduleRepository
    : IScheduleRepository
{
    private readonly SchoolECMContext _context;

    public IUnitOfWork UnitOfWork => _context;

    public ScheduleRepository(SchoolECMContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public Schedule Add(Schedule schedule)
    {
        return _context.Schedules.Add(schedule).Entity;
    }

    public async Task<Schedule> GetAsync(int scheduleId)
    {
        var schedule = await _context.Schedules.FindAsync(scheduleId);

        /*if (schedule != null)
        {
            await _context.Entry(schedule)
                .Collection(i => i.Sc).LoadAsync();
        }*/

        return schedule;
    }

    /*public void Update(Schedule schedule)
    {
        _context.Update();
    }*/

    public async Task<List<Schedule>> GetAllAsync(int groupId)
    {
        return await _context.Schedules.Where(g => g.Group.Id == groupId).ToListAsync();
    }
}

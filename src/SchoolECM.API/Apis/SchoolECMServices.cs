public class SchoolECMServices(
    IMediator mediator,
    IScheduleQueries queries,
    IIdentityService identityService,
    ILogger<SchoolECMServices> logger)
{
    public IMediator Mediator { get; set; } = mediator;
    public ILogger<SchoolECMServices> Logger { get; } = logger;
    public IScheduleQueries Queries { get; } = queries;
    public IIdentityService IdentityService { get; } = identityService;
}

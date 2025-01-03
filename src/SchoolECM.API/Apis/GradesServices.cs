public class GradesServices(
    IMediator mediator,
    IGradesQueries queries,
    IIdentityService identityService,
    ILogger<GradesServices> logger)
{
    public IMediator Mediator { get; set; } = mediator;
    public ILogger<GradesServices> Logger { get; } = logger;
    public IGradesQueries Queries { get; } = queries;
    public IIdentityService IdentityService { get; } = identityService;
}

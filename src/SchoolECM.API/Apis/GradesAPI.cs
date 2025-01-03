using Microsoft.AspNetCore.Http.HttpResults;
using Order = eShop.Ordering.API.Application.Queries.Order;

public static class GradesApi
{
    public static RouteGroupBuilder MapGradesApiV1(this IEndpointRouteBuilder app)
    {
        var api = app.MapGroup("api/grades").HasApiVersion(1.0);

        api.MapGet("{disciplineId:int}/{groupId:int}/group", GetGradesByGroupAndDisciplineAsync);
        api.MapGet("{disciplineId:int}", GetGradesByUserAsync);
        /*api.MapGet("/cardtypes", GetCardTypesAsync);*/
        /*api.MapPost("/draft", CreateOrderDraftAsync);
        api.MapPost("/", CreateOrderAsync);*/

        return api;
    }
    public static async Task<Ok<GradesByDisciplineAndGroup>> GetGradesByGroupAndDisciplineAsync(int disciplineId, int groupId, [AsParameters] GradesServices services)
    {
        var userId = services.IdentityService.GetUserIdentity();
        var gradesByDateTime = await services.Queries.GetGradesByGroupAndDisciplineAsync(userId, disciplineId, groupId);
        return TypedResults.Ok(gradesByDateTime);        
    }

    public static async Task<Ok<GradesByDisciplineAndStudent>> GetGradesByUserAsync(int disciplineId, [AsParameters] GradesServices services)
    {
        var userId = services.IdentityService.GetUserIdentity();
        var gradesByDateTime = await services.Queries.GetGradesByStudentAndDisciplineAsync(userId, disciplineId);
        return TypedResults.Ok(gradesByDateTime);
    }
}

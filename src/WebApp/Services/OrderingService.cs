using eShop.WebAppComponents.Catalog;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eShop.WebApp.Services;

public class OrderingService(HttpClient httpClient)
{
    private readonly string remoteServiceBaseUrl = "/api/schedule/";
    private readonly string remoteServiceBaseUrl2 = "/api/grades/";

    public Task<OrderRecord[]> GetOrders()
    {
        return httpClient.GetFromJsonAsync<OrderRecord[]>(remoteServiceBaseUrl)!;
    }

    public Task<ScheduleDetails?> GetScheduleDetails(int id)
    {
        var uri = $"{remoteServiceBaseUrl}{id}";
        return httpClient.GetFromJsonAsync<ScheduleDetails>(uri);
    }

    public Task CreateOrder(CreateOrderRequest request, Guid requestId)
    {
        var requestMessage = new HttpRequestMessage(HttpMethod.Post, remoteServiceBaseUrl);
        requestMessage.Headers.Add("x-requestid", requestId.ToString());
        requestMessage.Content = JsonContent.Create(request);
        return httpClient.SendAsync(requestMessage);
    }

    public async Task<List<ScheduleSummary?>?> GetSchedule()
    {
        var uri = $"{remoteServiceBaseUrl}";
        List<ScheduleSummary?>? result;
        try
        {
            result = await httpClient.GetFromJsonAsync<List<ScheduleSummary?>>(uri);
        }
        catch (Exception)
        {
            result = null;
        }
        return result;
    }

    public async Task<List<Discipline>?> GetAllDisciplines()
    {
        var uri = $"{remoteServiceBaseUrl}disciplines";
        List<Discipline>? result;
        try
        {
            result = await httpClient.GetFromJsonAsync<List<Discipline>>(uri);
        }
        catch (Exception)
        {
            result = null;
        }
        return result;
    }

    public async Task<GradesByStudentAndDiscipline?> GetGradesByStudentAndDiscipline(int disciplineId)
    {
        var uri = $"{remoteServiceBaseUrl2}{disciplineId}";
        return await httpClient.GetFromJsonAsync<GradesByStudentAndDiscipline>(uri);
    }

    public async Task<List<Group>?> GetGroups(int disciplineId)
    {
        var uri = $"{remoteServiceBaseUrl}groups/{disciplineId}";
        return await httpClient.GetFromJsonAsync<List<Group>>(uri);
    }
}

public record OrderRecord(
    int OrderNumber,
    DateTime Date,
    string Status,
    decimal Total);

public record ScheduleDetails(
    int Id,
    int DisciplineId,
    string DisciplineName,
    string DisciplineDescription,
    DateOnly Date,
    TimeOnly Time,
    string TeacherName,
    int RoomNumber);

public record GradesByStudentAndDiscipline
    (string DisciplineName,
    Dictionary<DateTime, int?> GradesByDateTime);

public record GradesByGroupAndDiscipline
    (Dictionary<int, Dictionary<DateTime, int?>> Grades);

public record ScheduleSummary(
    int Id,
    string DisciplineName,
    DateOnly Date,
    TimeOnly Time,
    string TeacherName);

public record Discipline(
    int Id,
    string DisciplineName);

public record Group(
    int Id,
    string GroupName);

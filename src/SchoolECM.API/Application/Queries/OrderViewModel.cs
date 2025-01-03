namespace eShop.Ordering.API.Application.Queries;

public record Orderitem
{
    public string ProductName { get; init; }
    public int Units { get; init; }
    public double UnitPrice { get; init; }
    public string PictureUrl { get; init; }
}

public record Order
{
    public int OrderNumber { get; init; }
    public DateTime Date { get; init; }
    public string Status { get; init; }
    public string Description { get; init; }
    public string Street { get; init; }
    public string City { get; init; }
    public string State { get; init; }
    public string Zipcode { get; init; }
    public string Country { get; init; }
    public List<Orderitem> OrderItems { get; set; }
    public decimal Total { get; set; }
}

public record ScheduleSummary
{
    public int Id { get; init; }
    public string DisciplineName { get; init; }
    public DateOnly Date { get; init; }
    public TimeOnly Time { get; init; }
    public string TeacherName { get; init; }
}

public record ScheduleDetails
{   
    public int Id { get; init; }
    public int DisciplineId { get; init; }
    public string DisciplineName { get; init; }
    public string DisciplineDescription { get; init; }
    public DateOnly Date { get; init; }
    public TimeOnly Time { get; init; }
    public string TeacherName { get; init; }
    public int RoomNumber { get; init; }
}

public record DisciplineViewModel
{
    public int Id { get; init; }
    public string DisciplineName { get; init; }
}

public record GroupViewModel
{
    public int Id { get; init; }
    public string GroupName { get; init; }
}

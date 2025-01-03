namespace eShop.Ordering.API.Application.Queries
{
    public record GradesByDisciplineAndStudent
    {
        public string DisciplineName { get; init; }
        public Dictionary<DateTime, int?> GradesByDateTime { get; init; }
    }

    public record GradesByDisciplineAndGroup
    {
        public Dictionary<int, Dictionary<DateTime, int?>> GradesByStudent { get; init;}
    }

}

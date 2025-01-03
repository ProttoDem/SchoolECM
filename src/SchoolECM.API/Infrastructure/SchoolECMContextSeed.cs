namespace eShop.Ordering.API.Infrastructure;

using eShop.Ordering.Domain.AggregatesModel.SchoolAggregate;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

public class SchoolECMContextSeed: IDbSeeder<SchoolECMContext>
{
    public async Task SeedAsync(SchoolECMContext context)
    {
        var group = await context.Groups.FirstOrDefaultAsync(g => g.Year == 11 && g.Letter == 'A');

        if (group == null) {

            group = new Group
            {
                Year = 11,
                Letter = 'A'
            };

            context.Groups.Add(group);
        }
        
        var group2 = await context.Groups.FirstOrDefaultAsync(g => g.Year == 10 && g.Letter == 'B');

        if (group2 == null) {

            group2 = new Group
            {
                Year = 10,
                Letter = 'B'
            };

            context.Groups.Add(group2);
        }

        var alice = await context.Students.FirstOrDefaultAsync(s => s.Name == "Alice");

        if (alice == null)
        {
            alice = new Student
            {
                IdentityGuid = "fbdd420e-d317-4899-bf25-c2965140ebd7",
                Street = "",
                City= "",
                State= "",
                Country= "",
                LastName= "Smith",
                ZipCode= "",
                Name = "Alice",
                Group = group
            };

            var result = context.Students.Add(alice);
        }

        var bob = await context.Students.FirstOrDefaultAsync(s => s.Name == "Bob");

        if (bob == null)
        {
            bob = new Student
            {
                IdentityGuid = "9e8c598d-9219-46e8-a378-f3e292b24d20",
                Street = "",
                City = "",
                State = "",
                Country = "",
                LastName = "Smith",
                ZipCode = "",
                Name = "Bob",
                Group = group
            };

            var result = context.Students.Add(bob);
        }

        var jhon = await context.Teachers.FirstOrDefaultAsync(s => s.Name == "Jhon");

        if (jhon == null)
        {
            jhon = new Teacher
            {
                IdentityGuid = "bead59a7-4320-4e70-95b1-2ad6323ccc77",
                Street = "",
                City = "",
                State = "",
                Country = "",
                LastName = "Smith",
                ZipCode = "",
                Name = "Jhon"
            };

            var result = context.Teachers.Add(jhon);
        }

        var dafna = await context.Teachers.FirstOrDefaultAsync(s => s.Name == "Dafna");

        if (dafna == null)
        {
            dafna = new Teacher
            {
                IdentityGuid = "7ca39d31-84fd-4d01-871b-7f0c5696a394",
                Street = "",
                City = "",
                State = "",
                Country = "",
                LastName = "Smith",
                ZipCode = "",
                Name = "Dafna"
            };

            var result = context.Teachers.Add(dafna);
        }

        var math = await context.Disciplines.FirstOrDefaultAsync(s => s.DisciplineName == "Math");

        if (math == null)
        {
            math = new Discipline("Math", "math", "It's math lesson.");

            var result = context.Disciplines.Add(math);
        }

        var ukr = await context.Disciplines.FirstOrDefaultAsync(s => s.DisciplineName == "Ukrainian");

        if (ukr == null)
        {
            ukr = new Discipline("Ukrainian", "ukr", "It's ukrainian language lesson.");

            var result = context.Disciplines.Add(ukr);
        }

        var sch1 = await context.Schedules.FirstOrDefaultAsync(s => s.Group == group);

        if (sch1 == null)
        {
            sch1 = new Schedule
            {
                DisciplineTime = new TimeOnly(8, 30),
                DisciplineDate = new DateOnly(2025, 01, 03),
                RoomNumber = 1,
                Group = group,
                Teacher = jhon,
                Discipline = math
            };

            var result = context.Schedules.Add(sch1);
        }

        var sch2 = await context.Schedules.FirstOrDefaultAsync(s => s.Group == group);

        if (sch2 == null)
        {
            sch2 = new Schedule
            {
                DisciplineTime = new TimeOnly(10, 0),
                DisciplineDate = new DateOnly(2025, 01, 02),
                RoomNumber = 5,
                Group = group,
                Teacher = dafna,
                Discipline = ukr
            };

            var result = context.Schedules.Add(sch2);
        }

        var sch3 = await context.Schedules.FirstOrDefaultAsync(s => s.Group == group);

        if (sch3 == null)
        {
            sch3 = new Schedule
            {
                DisciplineTime = new TimeOnly(11, 0),
                DisciplineDate = new DateOnly(2025, 01, 02),
                RoomNumber = 1,
                Group = group,
                Teacher = jhon,
                Discipline = math
            };

            var result = context.Schedules.Add(sch3);
        }

        var grade1 = await context.Grades.FirstOrDefaultAsync(s => s.Schedule == sch1);

        if (grade1 == null)
        {
            grade1 = new Grade
            {
               Value = 1,
               Schedule = sch1,
               Student = alice
            };

            var result = context.Grades.Add(grade1);
        }

        var grade2 = await context.Grades.FirstOrDefaultAsync(s => s.Schedule == sch2);

        if (grade2 == null)
        {
            grade2 = new Grade
            {
                Value = -1,
                Schedule = sch2,
                Student = alice
            };

            var result = context.Grades.Add(grade2);
        }

        var grade3 = await context.Grades.FirstOrDefaultAsync(s => s.Schedule == sch3);

        if (grade3 == null)
        {
            grade3 = new Grade
            {
                Value = 4,
                Schedule = sch3,
                Student = alice
            };

            var result = context.Grades.Add(grade3);
        }

        var grade4 = await context.Grades.FirstOrDefaultAsync(s => s.Schedule == sch1);

        if (grade4 == null)
        {
            grade4 = new Grade
            {
                Value = 2,
                Schedule = sch1,
                Student = bob
            };

            var result = context.Grades.Add(grade4);
        }

        await context.SaveChangesAsync();
    }

    /*private static IEnumerable<CardType> GetPredefinedCardTypes()
    {
        return Enumeration.GetAll<CardType>();
    }*/
}

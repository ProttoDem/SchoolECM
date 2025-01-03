using System.ComponentModel.DataAnnotations;

namespace eShop.Ordering.Domain.AggregatesModel.SchoolAggregate;

public class Schedule
    : Entity, IAggregateRoot
{
    [Required]
    public TimeOnly DisciplineTime { get; set; }
    [Required]
    public DateOnly DisciplineDate { get; set; }

    public int RoomNumber { get; set; }

    [Required]
    public Group Group { get; set; }
    [Required]
    public Discipline Discipline { get; set; }
    [Required]
    public Teacher Teacher { get; set; }

}

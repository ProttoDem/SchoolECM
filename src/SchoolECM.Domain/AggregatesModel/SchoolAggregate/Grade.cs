using System.ComponentModel.DataAnnotations;

namespace eShop.Ordering.Domain.AggregatesModel.SchoolAggregate;

public class Grade
    : Entity, IAggregateRoot
{
    public int Value { get; set; }

    [Required]
    public Student Student { get; set; }

    [Required]
    public Schedule Schedule { get; set; }

}

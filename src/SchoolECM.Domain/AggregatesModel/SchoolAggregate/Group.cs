using System.ComponentModel.DataAnnotations;

namespace eShop.Ordering.Domain.AggregatesModel.SchoolAggregate;

public class Group
    : Entity
{
    [Required]
    public int Year { get; set; }
    [Required]
    public char Letter { get; set; }

    /*protected Teacher() { }*/

    /*public Teacher(string disciplineName, string pictureUrl, string description, int teacherId)
    {
        DisciplineName = disciplineName;
        Description = description;
        PictureUrl = pictureUrl;
        TeacherId = teacherId;
    }*/
}

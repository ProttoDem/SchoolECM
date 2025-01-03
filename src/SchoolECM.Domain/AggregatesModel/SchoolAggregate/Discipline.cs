using System.ComponentModel.DataAnnotations;

namespace eShop.Ordering.Domain.AggregatesModel.SchoolAggregate;

public class Discipline
    : Entity
{
    [Required]
    public string DisciplineName { get; private set; }
    
    public string PictureUrl { get; private set;}
    
    public string Description { get; private set;}

    protected Discipline() { }

    public Discipline(string disciplineName, string pictureUrl, string description)
    {
        DisciplineName = disciplineName;
        Description = description;
        PictureUrl = pictureUrl;
    }
}

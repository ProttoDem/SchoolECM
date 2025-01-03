using System.ComponentModel.DataAnnotations;

namespace eShop.Ordering.Domain.AggregatesModel.SchoolAggregate;

public class Student
    : Entity
{
    [Required]
    public string IdentityGuid { get; set; }
    public string Street { get; set; }
    
    public string City { get; set; }
    
    public string State { get; set; }
    
    public string Country { get; set; }
    
    public string ZipCode { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public Group Group { get; set; }

    /*protected Teacher() { }*/

    /*public Teacher(string disciplineName, string pictureUrl, string description, int teacherId)
    {
        DisciplineName = disciplineName;
        Description = description;
        PictureUrl = pictureUrl;
        TeacherId = teacherId;
    }*/
}

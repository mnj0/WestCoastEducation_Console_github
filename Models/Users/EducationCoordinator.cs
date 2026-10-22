using WestCoastEducation.Models.Interfaces;

namespace WestCoastEducation.Models.Users;

public record class EducationCoordinator : Teacher, IEducationCordinator
{
    public required string StartOfEmployment {get; set;}
    public required string EndOfEmployment {get; set;}
}

namespace WestCoastEducation.Models.Users;

public record class EducationCoordinator : Teacher
{
    public required string StartOfEmployment {get; set;}
    public required string EndOfEmployment {get; set;}
}

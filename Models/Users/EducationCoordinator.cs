using WestCoastEducation.Models.Interfaces;

namespace WestCoastEducation.Models.Users;

public record class EducationCoordinator : Teacher, IEducationCordinator
{
    public required string OverSeeingCourses {get; set;}
}

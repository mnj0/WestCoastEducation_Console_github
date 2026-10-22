using WestCoastEducation.Models.Interfaces;

namespace WestCoastEducation.Models.Users;

public record class Teacher : Student, ITeacher
{
    public required string FieldOfKnowledge {get; set;}
    public required string OverSeeingCourses {get; set;}
}

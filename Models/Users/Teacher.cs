namespace WestCoastEducation.Models.Users;

public record class Teacher : Student
{
    public required string FieldOfKnowledge {get; set;}
    public required string OverSeeingCourses {get; set;}
}

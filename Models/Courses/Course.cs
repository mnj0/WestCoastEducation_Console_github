namespace WestCoastEducation.Models.Courses;

public record class Course
{
    public string CourseNumber {get; set; } = Guid.NewGuid().ToString();
    public required string Titel {get; set;}

    //Antal veckor i längd
    public required string Length {get; set;}
    public required string StartDate {get; set;}
    public required string EndDate {get; set;}
}

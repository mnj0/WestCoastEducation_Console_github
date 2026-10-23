using WestCoastEducation.Models.Interfaces;
using WestCoastEducation.Models.Persistance;

namespace WestCoastEducation.Models.Course;

public record class Course : ICourse
{
    public string Id {get; set; } = Guid.NewGuid().ToString();
    public required string Titel {get; set;}

    //Antal veckor i längd
    public required string HowManyWeeks {get; set;}
    public required string StartDate {get; set;}
    public required string EndDate {get; set;}

    //om det är distans, hybrid eller på plats. Komm ej på ett bra namn
    public required string TypeOfCourse {get; set;}

    public virtual void CourseAdd(Course course, string jsonfile)
    {
        string jsonfilepath = string.Concat(Environment.CurrentDirectory, $"/Data/{jsonfile}");
        var courses = JsonReader<Course>.ReadFromJson(jsonfilepath);
        courses.Add((Course)course);
        JsonWriter<Course>.WriteToJson(courses, jsonfilepath);
    }
    public override string ToString()
    {
        return $"Id: {Id}\n Titel: {Titel}\n Antal Veckor: {HowManyWeeks}\n Start Datum: {StartDate}\n Slut Datum: {EndDate}\n KursTyp: {TypeOfCourse}\n ";
    }
}

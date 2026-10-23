using WestCoastEducation.Models.Interfaces;
using WestCoastEducation.Models.Persistance;

namespace WestCoastEducation.Models.Users;

public record class Teacher : Student, ITeacher
{
    public required string FieldOfKnowledge {get; set;}
    public required string Courses {get; set;}
    public string? StartOfEmployment {get; set;}
    public string? EndOfEmployment {get; set;}
    public virtual void TeacherAdd(Teacher teacher, string jsonfile)
    {
        string jsonfilepath = string.Concat(Environment.CurrentDirectory, $"/Data/{jsonfile}");
        var teachers = JsonReader<Teacher>.ReadFromJson(jsonfilepath);
        teachers.Add((Teacher)teacher);
        JsonWriter<Teacher>.WriteToJson(teachers, jsonfilepath);
    }
    public override string ToString()
    {
        return base.ToString() + $" Kunskaper: {FieldOfKnowledge}\n Kurser: {Courses}\n Anställnings Start: {StartOfEmployment}\n Slut På Anställning: {EndOfEmployment}\n";
    }
}

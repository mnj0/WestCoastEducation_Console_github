using WestCoastEducation.Models.Interfaces;
using WestCoastEducation.Models.Persistance;

namespace WestCoastEducation.Models.Users;

public record class EducationCoordinator : Teacher, IEducationCordinator
{
    public required string OverSeeingCourses {get; set;}

    public virtual void ECAdd(EducationCoordinator ec, string jsonfile)
    {
        string jsonfilepath = string.Concat(Environment.CurrentDirectory, $"/Data/{jsonfile}");
        var ecs = JsonReader<EducationCoordinator>.ReadFromJson(jsonfilepath);
        ecs.Add((EducationCoordinator)ec);
        JsonWriter<EducationCoordinator>.WriteToJson(ecs, jsonfilepath);
    }
    public override string ToString()
    {
        return base.ToString() + $" översikt för dessa kurser: {OverSeeingCourses}\n";
    }
}

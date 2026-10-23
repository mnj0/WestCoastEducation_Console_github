using WestCoastEducation.Models.Interfaces;
using WestCoastEducation.Models.Persistance;

namespace WestCoastEducation.Models.Users;

public record class Admin : EducationCoordinator, IAdmin
{
    public required string AccesPass { get ; set;}

    public virtual void AdminAdd(Admin admin, string jsonfile)
    {
        string jsonfilepath = string.Concat(Environment.CurrentDirectory, $"/Data/{jsonfile}");
        var admins = JsonReader<Admin>.ReadFromJson(jsonfilepath);
        admins.Add((Admin)admin);
        JsonWriter<Admin>.WriteToJson(admins, jsonfilepath);
    }
    public override string ToString()
    {
        return base.ToString() + $" AcessPass: {AccesPass}";
    }
}

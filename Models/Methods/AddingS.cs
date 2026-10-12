using System;
using WestCoastEducation.Models.Persistance;
using WestCoastEducation.Models;
using WestCoastEducation.Models.Users;

namespace WestCoastEducation.Models.Methods;

public record AddingS : Student
{
    public override void Add(Student student)
    {
        string jsonfilepath = string.Concat(Environment.CurrentDirectory,"/Data/cars.json");
        
        var Items = JsonReader<Student>.ReadFromJson(jsonfilepath);
        Items.Add((AddingS)student);
        //JsonWriter<AddingS>.WriteToJson(Items,jsonfilepath);
    }
}

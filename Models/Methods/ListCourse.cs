using System;
using static WestCoastEducation.Assets.Styles.TypeWriterMethods;
using WestCoastEducation.Models.Persistance;
using WestCoastEducation.Models.Interfaces;

namespace WestCoastEducation.Models.Methods;

public class ListCourse
{
    public static void ShowCourseList<T>(string jsonfilepath)where T : class, ICourse
    {
        jsonfilepath = string.Concat(Environment.CurrentDirectory, $"/Data/{jsonfilepath}");
        var users = JsonReader<T>.ReadFromJson(jsonfilepath);
        string userslist = string.Join("\n", users);
        smarkupmedelande(userslist);
        
    }
}

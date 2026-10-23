using System;
using Spectre.Console;
using WestCoastEducation.Models.Interfaces;
using WestCoastEducation.Models.Persistance;
using WestCoastEducation.Models.Users;
using static WestCoastEducation.Assets.Styles.TypeWriterMethods;

namespace WestCoastEducation_Console.Models.Methods;

public static class ListUser
{
    public static void ShowStudentList<T>(string jsonfilepath)where T : class, IUser
    {
        jsonfilepath = string.Concat(Environment.CurrentDirectory, $"/Data/{jsonfilepath}");
        var users = JsonReader<T>.ReadFromJson(jsonfilepath);
        string userslist = string.Join("\n", users);
        smarkupmedelande(userslist);
        
    }
    public static void ShowTeacherList<T>(string jsonfilepath)where T : class, ITeacher
    {
        jsonfilepath = string.Concat(Environment.CurrentDirectory, $"/Data/{jsonfilepath}");
        var users = JsonReader<T>.ReadFromJson(jsonfilepath);
        string userslist = string.Join("\n", users);
        smarkupmedelande(userslist);
        
    }
    public static void ShowECList<T>(string jsonfilepath)where T : class, IUser
    {
        jsonfilepath = string.Concat(Environment.CurrentDirectory, $"/Data/{jsonfilepath}");
        var users = JsonReader<T>.ReadFromJson(jsonfilepath);
        string userslist = string.Join("\n", users);
        smarkupmedelande(userslist);
        
    }
    public static void ShowAdminList<T>(string jsonfilepath)where T : class, IAdmin
    {
        jsonfilepath = string.Concat(Environment.CurrentDirectory, $"/Data/{jsonfilepath}");
        var users = JsonReader<T>.ReadFromJson(jsonfilepath);
        string userslist = string.Join("\n", users);
        smarkupmedelande(userslist);
        
    }
    public static void ShowList<T>(string jsonfilepath)where T : class, IUser
    {
        jsonfilepath = string.Concat(Environment.CurrentDirectory, $"/Data/{jsonfilepath}");
        var users = JsonReader<T>.ReadFromJson(jsonfilepath);
        string userslist = string.Join("\n", users);
        smarkupmedelande(userslist);
        
    }
}

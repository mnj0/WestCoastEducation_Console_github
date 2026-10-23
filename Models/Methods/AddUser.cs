using System;
using WestCoastEducation.Models.Interfaces;
using WestCoastEducation.Models.Persistance;
using WestCoastEducation.Models.Users;
using static WestCoastEducation.Assets.Styles.TypeWriterMethods;

namespace WestCoastEducation.Models.Methods;

public record AddUser 
{
    public static void AddStudent()
    {
        smarkupmedelande("För att regristrera ett student konto måste du svara på några frågor");
        var förnamn = sfråga<String>("Vad är användarens Förnamn?");
        var efternamn = sfråga<String>("Vad är användarens Efternamn?");
        var mejl = sfråga<String>("Vad är användarens email?");
        var personnummer = sfråga<String>("Vad är användarens personnummer? (ååååmmdd-xxxx)");
        var LösenOrd = sfråga<String>("Skriv in ett LösenOrd till användaren");
        medelande($"här är dina svar: {förnamn}, {efternamn}, {mejl}, {personnummer}, {LösenOrd}");
        Student nyStudent = new()
        {
            FirstName = förnamn,
            LastName = efternamn,
            Email = mejl,
            SocialSecurityNumber = personnummer,
            PassWord = LösenOrd,

        };
        
        nyStudent.StudentAdd(nyStudent, "students.json");
    }
    public static void AddTeacher()
    {
        smarkupmedelande("För att regristrera ett konto dedikerat för lärare måste du svara på några frågor");
        var förnamn = sfråga<String>("Vad är användarens Förnamn?");
        var efternamn = sfråga<String>("Vad är användarens Efternamn?");
        var mejl = sfråga<String>("Vad är användarens email?");
        var personnummer = sfråga<String>("Vad är användarens personnummer? (ååååmmdd-xxxx)");
        var LösenOrd = sfråga<String>("Skriv in ett LösenOrd till användaren");
        var kunskapsområde = sfråga<String>("Vad är användarens kunskapsområde?");
        var kurser = sfråga<String>("Vilka kurser ska användaren ha koll på");
        medelande($"här är dina svar: {förnamn}, {efternamn}, {mejl}, {personnummer}, {LösenOrd}, {kunskapsområde} , {kurser}");
        Teacher nyTeacher = new()
        {
            FirstName = förnamn,
            LastName = efternamn,
            Email = mejl,
            SocialSecurityNumber = personnummer,
            PassWord = LösenOrd,
            FieldOfKnowledge = kunskapsområde,
            Courses = kurser,

        };
        
        nyTeacher.TeacherAdd(nyTeacher, "teachers.json");
    }
    public static void AddEducationCordinator()
    {
        smarkupmedelande("För att regristrera ett Handledar konto måste du svara på några frågor");
        var förnamn = sfråga<String>("Vad är användarens Förnamn?");
        var efternamn = sfråga<String>("Vad är användarens Efternamn?");
        var mejl = sfråga<String>("Vad är användarens email?");
        var personnummer = sfråga<String>("Vad är användarens personnummer? (ååååmmdd-xxxx)");
        var LösenOrd = sfråga<String>("Skriv in ett LösenOrd till användaren");
        var översiktklasser = sfråga<String>("Vilka klasser har användaren översikt över");
        medelande($"här är dina svar: {förnamn}, {efternamn}, {mejl}, {personnummer}, {översiktklasser}");
        EducationCoordinator nyEducationCoordinator = new()
        {
            FirstName = förnamn,
            LastName = efternamn,
            Email = mejl,
            SocialSecurityNumber = personnummer,
            PassWord = LösenOrd,
            FieldOfKnowledge = "/",
            Courses = "/",
            OverSeeingCourses = översiktklasser,

        };
        
        nyEducationCoordinator.ECAdd(nyEducationCoordinator, "educationcoordinators.json");
    }


    //här är generiskt metod men för någon anledning vill den inte att User Modellerna ska ha Required så jag skiter i denna.
    public static void Add<T>(string jsonfileName) where T : class, IUser, new()
    {
        
        string jsonfilepath = string.Concat(Environment.CurrentDirectory, $"/Data/{jsonfileName}");

        List<T> users = JsonReader<T>.ReadFromJson(jsonfilepath);

        T user = new()
        {
             FirstName = sfråga<string>("Vad är ditt Förnamn?"),
             LastName = sfråga<string>("Vad är ditt Efternamn?"),
             Email = sfråga<string>("Vad är din email?"),
             SocialSecurityNumber = sfråga<string>("Vad är ditt personnummer? (ååååmmdd-xxxx)")
        };

        if (user is ITeacher teacher)
        {
             teacher.FieldOfKnowledge = sfråga<string>("Vad är ditt kunskapsområde?");
             teacher.Courses = sfråga<string>("Vilka kurser ansvarar du för?");
        }

        if (user is IEducationCordinator coordinator)
        {
             coordinator.StartOfEmployment = sfråga<string>("När började du?");
             coordinator.EndOfEmployment = sfråga<string>("När slutar du?");
        }

        users.Add(user);
         JsonWriter<T>.WriteToJson(users, jsonfilepath);
         smarkupmedelande("[green]Sparat.[/]");
    }
}

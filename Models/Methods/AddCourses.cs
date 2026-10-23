using System;
using static WestCoastEducation.Assets.Styles.TypeWriterMethods;
using WestCoastEducation.Models.Course;
using System.Reflection;

namespace WestCoastEducation_Console.Models.Methods;

public class AddCourses
{
    public static void AddCourse()
    {
        smarkupmedelande("För att lägga till en kurs måste du svara på några frågor");
        var titel = sfråga<String>("Vad är Titeln på Kursen?");
        var antalveckor = sfråga<String>("Hur många veckor är kursen?");
        var startdatum = sfråga<String>("Vilket Datum börjar kursen? (åååå-mm-dd)");
        var slutdatum = sfråga<String>("Vilket Datum slutar kursen? (åååå-mm-dd)");
        var kurstyp = sfråga<String>("Är kursen på Distans?, på Plats? eller en Hybrid kurs?");
        medelande($"här är dina svar: {titel}, {antalveckor}, {startdatum}, {slutdatum}, {kurstyp}");
        Course nyKurs = new()
        {

            //CourseNumber = 
            Titel = titel,
            HowManyWeeks = antalveckor,
            StartDate = startdatum,
            EndDate = slutdatum,
            TypeOfCourse = kurstyp,

        };
        
        nyKurs.CourseAdd(nyKurs, "courses.json");
    }
}

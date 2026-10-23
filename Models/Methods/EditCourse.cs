using System;
using Spectre.Console;
using WestCoastEducation.Models.Interfaces;
using WestCoastEducation.Models.Persistance;
using static WestCoastEducation.Assets.Styles.TypeWriterMethods;

namespace WestCoastEducation.Models.Methods;

public static class EditCourse
{
    public static void Edit<T>(string jsonfilepath) where T : class, ICourse
    {
        var courses = JsonReader<T>.ReadFromJson(jsonfilepath);
        
        smedelande("Ange Titeln på Kursen eller de 8 första tecknen av Id: ");
        T? course = CourseSearch.FindByIdOrTitel(courses, Console.ReadLine() ?? "");
        
        if (course == null)
        {
            smarkupmedelande("Ingen [red]Kurs[/] hittades.");
            return;
        }
        smarkupmedelande("Vad vill du redigera på denna Kursen?");
        var AnvändarensVal = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title($"{course.Titel}, {course.HowManyWeeks}, {course.StartDate}, {course.EndDate}, {course.TypeOfCourse}")
            .AddChoices("Titel", "Antal Veckor" , "Start Datum" , "Slut Datum" , "Kurs Typ"));
        switch (AnvändarensVal)
        {
            case "Titel":

                ChangeCourseItem("Skriv in en ny Titel", course.Titel, v => course.Titel = v);
                
            break;
            case "Antal Veckor":
                ChangeCourseItem("Skriv in hur många Antal Veckor du vill kursen ska ha", course.HowManyWeeks, v => course.HowManyWeeks = v);
            break;
            case "Start Datum":
                ChangeCourseItem("Skriv in ett nytt Start Datum", course.StartDate, v => course.StartDate = v);
            break;
            case "Slut Datum":
            ChangeCourseItem("Skriv in ett nytt Slut Datum", course.EndDate, v => course.EndDate = v);
            break;
            case "Kurs Typ":
                ChangeCourseItem("Skriv vad för ny Kurs Typ du vill kursen ska ha", course.TypeOfCourse, v => course.TypeOfCourse = v);
            break;
            
        }

        JsonWriter<T>.WriteToJson(courses, jsonfilepath);
        
    }
    
    private static void ChangeCourseItem(string label, string? current, Action<string> set)
    {
        try
        {
            while (true)
            {
                var nytt = sfråga<string>(label);
 
                smarkupmedelande($"Är du säker på du vill ersätta {current} Med {nytt}");
                string svar = sfråga<string>("svara med y/n eller yes/no").ToLower();
 
                if (string.IsNullOrWhiteSpace(svar))
                {
                    smarkupmedelande("Du skrev inte in något eller så va det tomt i ditt svar");
                }
                else if (svar is "y" or "yes")
                {
                    set(nytt);
                    smarkupmedelande("[green]Sparat.[/]");
                    return;
                }
                else if (svar is "n" or "no")
                {
                    smarkupmedelande("Ändringen [green strikethrough]Sparades[/] [Red]Ej![/]");
                    return;
                }
                else
                {
                    smarkupmedelande("Nånting gick fel när du svara y/n, Försök Igen");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

}

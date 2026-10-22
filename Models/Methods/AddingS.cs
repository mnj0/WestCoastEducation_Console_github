using System;
using WestCoastEducation.Models.Persistance;
using static WestCoastEducation.Assets.Styles.TypeWriterMethods;

namespace WestCoastEducation.Models.Methods;

public record AddingS : Student
{
    public void Add(Student student)
    {
        
        string jsonfilepath = string.Concat(Environment.CurrentDirectory, "/Data/students.json");

        List<Student> students = JsonReader<Student>.ReadFromJson(jsonfilepath);

         if (students.Count == 0)
        {
            smarkupmedelande("Inga konton finns. Skapa ett konto först.");
            smarkupmedelande("Okej för att regristrera ett konto måste du svara på några frågor");
            var förnamn = sfråga<String>("Vad är Ditt Förnamn?");
            var efternamn = sfråga<String>("Vad är Ditt Efternamn?");
            var mejl = sfråga<String>("Vad är din email?");
            var personnummer = sfråga<String>("Vad är ditt personnummer? [ååååmmdd-xxxx]");
            medelande($"här är dina svar: {förnamn}, {efternamn}, {mejl}, {personnummer}");
            Student nyStudent = new()
            {
                FirstName = förnamn,
                LastName = efternamn,
                Email = mejl,
                SocialSecurityNumber = personnummer

            };
                                    
                nyStudent.Add(nyStudent);
        }
        else
        {
            medelande("Du har redan registrerat ett konto.");
        }
    }
}

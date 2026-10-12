using Microsoft.VisualBasic;
using Spectre.Console;
using WestCoastEducation.Assets.FAQ;
using WestCoastEducation.Models;
using WestCoastEducation.Models.Users;

namespace WestCoastEducation;

public class MainProgram : SpectreConsole_FAQ
{
    static void Main()
    {
        while(true){

            smarkupmedelande("Välj ett av [DarkOliveGreen2]alternativen[/]");
            var AnvändarensVal = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                
                .AddChoices("Hem", "Kurser", "Bokning", "Profil", "Avsluta"));

            switch (AnvändarensVal)
            {
                case "Hem":
                    smarkupmedelande("Du är inuti Hem");
                    break;
                case "Kurser":
                    smarkupmedelande("Du är inuti Kurser");
                    break;
                case "Bokning":
                    smarkupmedelande("Du är inuti Bokningar");
                    break;
                case "Profil":
                    smarkupmedelande("Du är inuti Profil");

                    smarkupmedelande("Du är inte Inloggad välj vad du vill logga in som");

                    var AnvändarensVal2 = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                    .AddChoices("Student", "Lärare", "StudentHandledare", "Admin"));
                    switch (AnvändarensVal2)
                    {
                        case "Student":
                            smarkupmedelande("Okej för att regristrera ett konto måste du svara på några frågor");
                            var förnamn = sfråga<String>("Vad är Ditt Förnamn?");
                            var efternamn = sfråga<String>("Vad är Ditt Efternamn?");
                            var mejl = sfråga<String>("Vad är din email?");
                            var personnummer = sfråga<String>("Vad är ditt personnummer?");
                            Student nyStudent = new()
                            {
                                FirstName = förnamn,
                                LastName = efternamn,
                                Email = mejl,
                                SocialSecurityNumber = personnummer

                            };
                        break;
                        case "Lärare":
                            //Teacher nyTeacher = new()
                            {
                                
                            };
                        break;
                        case "StudentHandledare":
                            //EducationCoordinator nyEducationCordinator = new()
                            {
                                
                            };
                        break;
                        case "Admin":
                        //Admin nyAdmin = new()
                        {
                            
                        };
                        break;
                    }
                    break;
                case "Avsluta":
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }
    }

    
}

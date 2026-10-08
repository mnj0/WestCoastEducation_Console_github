using Microsoft.VisualBasic;
using Spectre.Console;

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

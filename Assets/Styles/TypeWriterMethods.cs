using Spectre.Console;

namespace WestCoastEducation;

//Använde Andras Kod för TypeWriter Stil som jag hitta online.

//Min Kod fungerar utan TypeWriterMethods.cs filen men Spectre.Console och ''vanliga'' Console använder bara 
//andra metoder som skriver ut output automatiskt.
//Det är BARA visuellt.
//Till exempel istället för Console.WriteLine("Hej"); blir till 
// Hej

// så blir ' medelande("Hej"); '
// H
// He
// Hej

// fast på samma rad såklart. Aka Som en typewriter. Den skriver ut en karaktär efter en istället för allt samtidigt.

//Anledningen jag ville ha det som en typewriter var för det SER SÅÅÅ mycket mer snyggagre ut I consolen.


public class TypeWriterMethods
{
    private static int Slowness = 20;
    private static int TabellSpeed = 5;
    public static string stitel_val(string titel, params string[] val)
{
    smarkupmedelande(titel);

    for (int i = 0; i < val.Length; i++)
        smarkupmedelande($"[grey]{i + 1}.[/] {Markup.Escape(val[i])}");

    int nummer = AnsiConsole.Prompt(
        new TextPrompt<int>("[grey]>[/]")
            .Validate(n => n >= 1 && n <= val.Length
                ? ValidationResult.Success()
                : ValidationResult.Error($"[red]Välj ett nummer mellan 1 och {val.Length}[/]")));

    return val[nummer - 1];
}
    public static void medelande(string dintext)
    {
        for (int i = 0; i < dintext.Length; i++ )
        {
            Console.Write(dintext[i]);
            Thread.Sleep(Slowness);
        }
        Console.WriteLine();
        Console.WriteLine();
    }
    public static void smedelande(string dintext)
    {
        var stilar = new Stack<string>();

        for (int i = 0; i < dintext.Length; i++)
        {
            char c = dintext[i];

            if ((c == '[' || c == ']') && i + 1 < dintext.Length && dintext[i + 1] == c)
            {
                i++;
            }
            else if (c == '[')
            {
                int slut = dintext.IndexOf(']', i);
                string tagg = dintext.Substring(i + 1, slut - i - 1);

                if (tagg == "/") stilar.Pop();
                else stilar.Push(tagg);

                i = slut;
                continue;
            }

            var stil = stilar.Count == 0
                ? Style.Plain
                : Style.Parse(string.Join(" ", stilar.Reverse()));

            AnsiConsole.Write(new Text(c.ToString(), stil));
            Thread.Sleep(Slowness);
        }

        AnsiConsole.WriteLine();
        AnsiConsole.WriteLine();
    }  
    public static void swritetabell(Table tabell)
    {
        var writer = new StringWriter();
        var konsol = AnsiConsole.Create(new AnsiConsoleSettings
        {
            Ansi = AnsiSupport.Yes,
            ColorSystem = ColorSystemSupport.TrueColor,
            Out = new AnsiConsoleOutput(writer)
        });
        konsol.Profile.Width = AnsiConsole.Profile.Width;
        konsol.Write(tabell);

        string text = writer.ToString();

        // 2. Skriv ut strängen ett tecken i taget
        var ut = AnsiConsole.Profile.Out.Writer;
        bool iEscape = false;

        foreach (char c in text)
        {
            ut.Write(c);

            if (c == '\u001b')
            {
                iEscape = true; 
            }
            else if (iEscape)
            {
                if (char.IsLetter(c)) iEscape = false; 
            }
            else if (c != '\n' && c != '\r')
            {
                ut.Flush();
                Thread.Sleep(TabellSpeed);
            }
        }

        ut.Flush();
        Console.WriteLine();
    }
    public static void smarkupmedelande(string dintext)
    {
        var stilar = new Stack<string>();

        for (int i = 0; i < dintext.Length; i++)
        {
            char c = dintext[i];

            if (c == '[' && i + 1 < dintext.Length && dintext[i + 1] == '[')
            {
                i++;
            }
            else if (c == ']' && i + 1 < dintext.Length && dintext[i + 1] == ']')
            {
                i++;
            }
            else if (c == '[')
            {
                int slut = dintext.IndexOf(']', i);
                string tagg = dintext.Substring(i + 1, slut - i - 1);

                if (tagg == "/") stilar.Pop();
                else stilar.Push(tagg);

                i = slut;
                continue;
            }

            string tecken = Markup.Escape(c.ToString());
            string stil = string.Join(" ", stilar.Reverse());

            if (stil == "")
                AnsiConsole.Markup(tecken);
            else
                AnsiConsole.Markup($"[{stil}]{tecken}[/]");

            Thread.Sleep(Slowness);
        }

        AnsiConsole.WriteLine();
    }
    public static Variabel sfråga<Variabel>(string fråga)
    {
        smarkupmedelande(fråga);
        return AnsiConsole.Ask<Variabel>("[grey]>[/]");
    }
}

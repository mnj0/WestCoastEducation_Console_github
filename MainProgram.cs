using Spectre.Console;

namespace WestCoastEducation;

public class MainProgram : SpectreConsole_FAQ
{
    static void Main()
    {
        medelande("WestCoastEducation");
        smedelande("[bold blue]Welcome[/] to [green]Spectre.Console[/]!");


        var namn = sfråga<string>("Vad Heter du?");
        smarkupmedelande($"Okej tack {namn}");

        

    }

}

using Spectre.Console;

namespace WestCoastEducation;

public class MainProgram : TypeWriterMethods
{
    static void Main()
    {
        medelande("WestCoastEducation");
        smedelande("[bold blue]Welcome[/] to [green]Spectre.Console[/]!");
        
        AnsiConsole.MarkupLine("[Bold]Den Här texten är Bold och från AnsiConsole[/]");

        smarkupmedelande("[bold]bold[/]          - bold /bright text");
        smarkupmedelande("[dim]dim[/]           - Dimmed/faint text");
        smarkupmedelande("[italic]italic[/]        - Italic text");
        smarkupmedelande("[underline]underline[/]     - Underlined text");
        smarkupmedelande("[strikethrough]strikethrough[/] - Strikethrough text");
        smarkupmedelande("[invert]invert[/]        - Swap foreground/background");
        smarkupmedelande("[conceal]conceal[/]       - Hidden text (for passwords)");
        AnsiConsole.MarkupLine("[slowblink]slowblink[/]     - Slowly blinking text");
        AnsiConsole.MarkupLine("[rapidblink]rapidblink[/]    - Rapidly blinking text");
    }
}

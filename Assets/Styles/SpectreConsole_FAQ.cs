using System;
using Spectre.Console;
using WestCoastEducation;

namespace WestCoastEducation;

public class SpectreConsole_FAQ : TypeWriterMethods
{
        private static void TabularDataExamples()
        {
                var table = new Table();
  
                table.AddColumn("Name");
                table.AddColumn("Department");
                table.AddColumn("Sales");
                
                table.AddRow("Alice", "North", "$12,400");
                table.AddRow("Bob", "South", "$8,750");
                table.AddRow("Carol", "West", "$15,200");
                
                AnsiConsole.Write(table);
        }
        private static void MarkupExamples()
        {
                var namn = sfråga<string>("Vad Heter du?");
                smarkupmedelande($"Okej tack {namn}");

                smarkupmedelande("[bold]bold[/]          - bold /bright text");
                smarkupmedelande("[dim]dim[/]           - Dimmed/faint text");
                smarkupmedelande("[italic]italic[/]        - Italic text");
                smarkupmedelande("[underline]underline[/]     - Underlined text");
                smarkupmedelande("[strikethrough]strikethrough[/] - Strikethrough text");
                smarkupmedelande("[invert]invert[/]        - Swap foreground/background");
                smarkupmedelande("[conceal]conceal[/]       - Hidden text (for passwords)");
        }

        private static void LayoutExamples()
        {
                var panel = new Panel("Important message")
                .Header("[yellow]Notice[/]")
                .BorderColor(Color.Yellow);
                
                AnsiConsole.Write(panel);

                var left = new Panel("Left content").Header("Panel 1");
                var right = new Panel("Right content").Header("Panel 2");
                
                AnsiConsole.Write(new Columns(left, right));

                var grid = new Grid();
                grid.AddColumn();
                grid.AddColumn();
                
                grid.AddRow("Name", "Alice");
                grid.AddRow("Role", "Developer");
                grid.AddRow("Team", "Platform");
                
                AnsiConsole.Write(grid);

                var panel2 = new Panel("Centered content")
                .Border(BoxBorder.Rounded);
                
                AnsiConsole.Write(Align.Center(panel2));
        }
        
}

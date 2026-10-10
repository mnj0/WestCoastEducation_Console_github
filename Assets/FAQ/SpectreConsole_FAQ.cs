using System;
using Spectre.Console;
using WestCoastEducation.Assets.Styles;

namespace WestCoastEducation.Assets.FAQ;

public class SpectreConsole_FAQ : TypeWriterMethods
{
        public static void UpdateContentLiveExamples()
        {
                var table = new Table().AddColumn("Metric").AddColumn("Value");
                AnsiConsole.Live(table)
                .Start(ctx =>
                {
                for (int i = 1; i <= 5; i++)
                {
                        table.AddRow($"Item {i}", $"{i * 10}%");
                        ctx.Refresh();
                        Thread.Sleep(500);
                }
                });

                AnsiConsole.Live(new Panel("Starting..."))
                .Start(ctx =>
                {
                Thread.Sleep(1000);
                ctx.UpdateTarget(new Panel("[yellow]Processing...[/]"));
                Thread.Sleep(1000);
                ctx.UpdateTarget(new Panel("[green]Complete![/]"));
                Thread.Sleep(500);
                });
                var table2 = new Table().AddColumn("Status");
        
                AnsiConsole.Live(table2)
                .AutoClear(true)
                .Start(ctx =>
                {
                        table2.AddRow("Working...");
                        ctx.Refresh();
                        Thread.Sleep(2000);
                });
                
                AnsiConsole.MarkupLine("[green]Done![/]");                
                smedelande("Starting...");
                TestLive().GetAwaiter().GetResult();
                smedelande("Finished!");
        }
        public static void TabularDataExamples()
        {
                var table = new Table();
  
                table.AddColumn("Name");
                table.AddColumn("Department");
                table.AddColumn("Sales");                        
                table.AddRow("Alice", "North", "$12,400");
                table.AddRow("Bob", "South", "$8,750");
                table.AddRow("Carol", "West", "$15,200");
                
                AnsiConsole.Write(table);

                var table2 = new Table()
                .RoundedBorder()
                .BorderColor(Color.Grey);
                
                table2.AddColumn("Name");
                table2.AddColumn("Department");
                table2.AddColumn("Sales");
                
                table2.AddRow("Alice", "North", "$12,400");
                table2.AddRow("Bob", "South", "$8,750");
                table2.AddRow("Carol", "West", "$15,200");
                
                swritetabell(table2);

                var table3 = new Table()
                .RoundedBorder()
                .BorderColor(Color.Grey);
                
                table3.AddColumn("Name");
                table3.AddColumn("Department", col => col.Centered());
                table3.AddColumn("Sales", col => col.RightAligned());
                
                table3.AddRow("Alice", "North", "$12,400");
                table3.AddRow("Bob", "South", "$8,750");
                table3.AddRow("Carol", "West", "$15,200");
                
                AnsiConsole.Write(table3);
        }
        public static void MarkupExamples()
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

        public static void LayoutExamples()
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
        public static async Task TestLive()
        {
                var table = new Table().AddColumn("Task").AddColumn("Status");

                await AnsiConsole.Live(table)
                .StartAsync(async ctx =>
                {
                        table.AddRow("Fetching data", "[yellow]...[/]");
                        ctx.Refresh();
                        await Task.Delay(1000);

                        table.Rows.Update(0, 1, new Markup("[green]Done[/]"));
                        ctx.Refresh();
                });
        }
}

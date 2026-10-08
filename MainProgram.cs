using Spectre.Console;

namespace WestCoastEducation;

public class MainProgram : TypeWriterMethods
{
    static void Main()
    {
        medelande("WestCoastEducation");
        smedelande("[bold blue]Welcome[/] to [green]Spectre.Console[/]!");

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
        var namn = sfråga<string>("Vad Heter du?");
        smarkupmedelande($"Okej tack {namn}");

        
    }
}

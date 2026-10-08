using Spectre.Console;

namespace WestCoastEducation;

public class MainProgram
{
    static void Main()
    {
        medelande("WestCoastEducation");
        smedelande("[bold blue]Welcome[/] to [green]Spectre.Console[/]!");
    }


    static void medelande(string dintext)
    {
        for (int i = 0; i < dintext.Length; i++ )
        {
            Console.Write(dintext[i]);
            Thread.Sleep(10);
        }
        Console.WriteLine();
        Console.WriteLine();
    }
    static void smedelande(string dintext)
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
            Thread.Sleep(10);
        }

        AnsiConsole.WriteLine();
        AnsiConsole.WriteLine();
    }
}

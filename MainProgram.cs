namespace WestCoastEducation;

public class MainProgram
{
    static void Main()
    {
        medelande("WestCoastEducation");
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
}

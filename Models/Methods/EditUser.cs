using System;
using Spectre.Console;
using WestCoastEducation.Models.Interfaces;
using WestCoastEducation.Models.Persistance;
using static WestCoastEducation.Assets.Styles.TypeWriterMethods;

namespace WestCoastEducation.Models.Methods;

public static class EditUser
{
    public static void Edit<T>(string jsonfilepath) where T : class, IUser
    {
        var users = JsonReader<T>.ReadFromJson(jsonfilepath);
        
        smedelande("Ange PersonNummer (yyyymmdd-xxxx) eller de 8 första tecknen av Id: ");
        T? user = UserSearch.FindByIdOrSocialSecurityNumber(users, Console.ReadLine() ?? "");
        
        if (user == null)
        {
            smarkupmedelande("Ingen [red]användare[/] hittades.");
            return;
        }
        smarkupmedelande("Vad vill du redigera på denna Användaren?");
        var AnvändarensVal = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title($"{user.FirstName}, {user.LastName}, {user.Email}, {user.SocialSecurityNumber}, {user.PassWord}, {user.Adress}, {user.PostCode}, {user.City}")
            .AddChoices($"FirstName", $"LastName", $"Email", 
            $"SocialSecurityNumber", "PassWord", $"Adress", 
            $"PostCode", $"City"));
        switch (AnvändarensVal)
        {
            case "FirstName":

                ChangeUserItem("Skriv in ett nytt FörNamn", user.FirstName, v => user.FirstName = v);
                
            break;
            case "LastName":
                ChangeUserItem("Skriv in ett nytt EfterNamn", user.LastName, v => user.LastName = v);
            break;
            case "Email":
                ChangeUserItem("Skriv in en ny Email", user.Email, v => user.Email = v);
            break;
            case "SocialSecurityNumber":
                ChangeUserItem("Skriv in ett nytt PersonNummer", user.SocialSecurityNumber, v => user.SocialSecurityNumber = v);
            break;
            case "PassWord":
                ChangeUserItem("Skriv in ett nytt LösenOrd", user.PassWord, v => user.PassWord = v);
            break;
            case "Adress":
                ChangeUserItem("Skriv in en ny Adress", user.Adress, v => user.Adress = v);
            break;
            case "PostCode":
                ChangeUserItem("Skriv in en ny PostKod", user.PostCode, v => user.PostCode = v);
            break;
            case "City":
                ChangeUserItem("Skriv in en ny Stad", user.City, v => user.City = v);
            break;
        }

        JsonWriter<T>.WriteToJson(users, jsonfilepath);
        
    }
    
    private static void ChangeUserItem(string label, string? current, Action<string> set)
    {
        try
        {
            while (true)
            {
                var nytt = sfråga<string>(label);
 
                smarkupmedelande($"Är du säker på du vill ersätta {current} Med {nytt}");
                string svar = sfråga<string>("svara med y/n eller yes/no").ToLower();
 
                if (string.IsNullOrWhiteSpace(svar))
                {
                    smarkupmedelande("Du skrev inte in något eller så va det tomt i ditt svar");
                }
                else if (svar is "y" or "yes")
                {
                    set(nytt);
                    smarkupmedelande("[green]Sparat.[/]");
                    return;
                }
                else if (svar is "n" or "no")
                {
                    smarkupmedelande("Ändringen [green strikethrough]Sparades[/] [Red]Ej![/]");
                    return;
                }
                else
                {
                    smarkupmedelande("Nånting gick fel när du svara y/n, Försök Igen");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

}

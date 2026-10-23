using Microsoft.VisualBasic;
using Spectre.Console;
using WestCoastEducation.Assets.FAQ;
using WestCoastEducation.Models;
using WestCoastEducation.Models.Persistance;
using WestCoastEducation.Models.Methods;
using WestCoastEducation.Models.Users;
using WestCoastEducation.Models.Course;
using WestCoastEducation_Console.Models.Methods;

namespace WestCoastEducation;
public class MainProgram : SpectreConsole_FAQ
{
    static void Main()
    {
        while(true){
            Console.WriteLine();
            smarkupmedelande("Välj ett av [DarkOliveGreen2]alternativen[/]");
            var AnvändarensVal = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                
                .AddChoices("Hem", "Add Course", "Add User", "List Courses", "List Users" ,"Edit Users", "Edit Courses", "Avsluta"));

            switch (AnvändarensVal)
            {
                case "Hem":
                    smarkupmedelande("Du är inuti Hem");
                    break;
                case "Add Course":
                    smarkupmedelande("Du är inuti Kurser");
                    AddCourses.AddCourse();
                    break;
                case "Add User":
                    smarkupmedelande("Du är inuti AddUser");

                    smarkupmedelande("Välj vad du vill lägga till");

                    var AnvändarensVal2 = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                    .AddChoices("Student", "Lärare", "Handledare", "Admin"));
                    switch (AnvändarensVal2)
                    {
                        case "Student":

                        AddUser.AddStudent();
                        //AddUser.Add<Teacher>("student.json");
                        /*
                                string jsonfilepath = string.Concat(Environment.CurrentDirectory, "/Data/students.json");

                                List<Student> students = JsonReader<Student>.ReadFromJson(jsonfilepath);

                                if (students.Count == 0)
                                {
                                    smarkupmedelande("Inga konton finns. Skapa ett konto först.");
                                    smarkupmedelande("Okej för att regristrera ett konto måste du svara på några frågor");
                                    var förnamn = sfråga<String>("Vad är Ditt Förnamn?");
                                    var efternamn = sfråga<String>("Vad är Ditt Efternamn?");
                                    var mejl = sfråga<String>("Vad är din email?");
                                    var personnummer = sfråga<String>("Vad är ditt personnummer? (ååååmmdd-xxxx)");
                                    medelande($"här är dina svar: {förnamn}, {efternamn}, {mejl}, {personnummer}");
                                    Student nyStudent = new()
                                    {
                                        FirstName = förnamn,
                                        LastName = efternamn,
                                        Email = mejl,
                                        SocialSecurityNumber = personnummer

                                    };
                                    
                                    nyStudent.Add(nyStudent);
                                }
                                else
                                {
                                    medelande("Du har redan registrerat ett konto.");
                                }*/

                        break;
                        case "Lärare":
                            //Teacher nyTeacher = new()
                            {
                                AddUser.AddTeacher();
                            };
                        break;
                        case "Handledare":
                            //EducationCoordinator nyEducationCordinator = new()
                            {
                                AddUser.AddEducationCordinator();
                            };
                        break;
                        case "Admin":
                        //Admin nyAdmin = new()
                        {
                            string jsonfilepath = string.Concat(Environment.CurrentDirectory, "/Data/admins.json");

                            List<Admin> students = JsonReader<Admin>.ReadFromJson(jsonfilepath);
                            Admin nyAdmin = new()
                            {
                                AccesPass = "d7nd3rH0nun5",
                                FirstName = "Björn",
                                LastName = "Bengtson",
                                Email = "bengabjörn@gmail.com",
                                SocialSecurityNumber = "19990120-8903",
                                PassWord = "DunderHonung",
                                FieldOfKnowledge = "Administriva Egenskaper",
                                StartOfEmployment = "2020-02-10",
                                EndOfEmployment = "Aldrig",
                                OverSeeingCourses = "Inga",
                                Courses = "Inga"

                            };
                            
                            nyAdmin.AdminAdd(nyAdmin, "admins.json");
                            medelande("");
                        };
                        break;
                    }
                    break;
                case "List Courses":
                    smarkupmedelande("Du är inuti ListCourses");
                    ListCourse.ShowCourseList<Course>("courses.json");
                    break;
                case "List Users":
                    smarkupmedelande("Du är inuti ListUsers");
                    smarkupmedelande("Välj vilken lista du vill se");
                    string LCSvar = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                    .AddChoices("Student", "Lärare", "Handledare", "Admin"));
                    switch (LCSvar)
                    {
                        case "Student":
                            ListUser.ShowStudentList<Student>("students.json");
                        break;
                        case "Lärare":
                            ListUser.ShowTeacherList<Teacher>("teachers.json");
                        break;
                        case "Handledare":
                            ListUser.ShowECList<EducationCoordinator>("educationcoordinators.json");
                        break;
                        case "Admin":
                            ListUser.ShowAdminList<Admin>("admins.json");
                        break;
                    } 
                break;  
                case "Edit Courses":
                    smarkupmedelande("Du är inuti Edit Courses");
                    string jsonfilepath3 = string.Concat(Environment.CurrentDirectory, "/Data/courses.json");
                    EditCourse.Edit<Course>(jsonfilepath3);
                    break;  
                case "Edit Users":
                    smarkupmedelande("Du är inuti EditUsers");
                    smarkupmedelande("Vill påmmina att jag bara har lagt till funktionell kod för Student och inget annat");
                    string jsonfilepath2 = string.Concat(Environment.CurrentDirectory, "/Data/students.json");
                    //går att implementera så man kan få specifik typ av json fil men för enkelhetensSkulle nu (sent) så gör jag inte det
                    EditUser.Edit<Student>(jsonfilepath2);
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

using System.Data.Common;
using WestCoastEducation.Models.Interfaces;
using WestCoastEducation.Models.Persistance;

namespace WestCoastEducation.Models;

public record class Student : IUser
{

    public string Id {get; set; } = Guid.NewGuid().ToString();
    public required string FirstName {get; set;}
    public required string LastName {get; set;}
    public required string Email {get; set;}
    public required string SocialSecurityNumber {get; set;}
    public string? PassWord {get; set;}
    public string? Adress {get; set;}
    public string? PostCode {get; set;}
    public string? City {get; set;}

    public virtual void StudentAdd(Student student, string jsonfile)
    {
        string jsonfilepath = string.Concat(Environment.CurrentDirectory, $"/Data/{jsonfile}");
        var students = JsonReader<Student>.ReadFromJson(jsonfilepath);
        students.Add((Student)student);
        JsonWriter<Student>.WriteToJson(students, jsonfilepath);
    }
    public override string ToString()
    {
        return $"Id: {Id}\n FörNamn: {FirstName}\n EfterNamn: {LastName}\n Email: {Email}\n PersonNummer {SocialSecurityNumber}\n";
    }
}

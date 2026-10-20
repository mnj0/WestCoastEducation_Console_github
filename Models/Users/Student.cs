using System.Data.Common;
using WestCoastEducation.Models.Persistance;

namespace WestCoastEducation.Models;

public record class Student
{
    public string id {get; set; } = Guid.NewGuid().ToString();
    public required string FirstName {get; set;}
    public required string LastName {get; set;}
    public required string Email {get; set;}
    public required string SocialSecurityNumber {get; set;}
    public string? Adress {get; set;}
    public string? PostCode {get; set;}
    public string? City {get; set;}

    public virtual void Add(Student student)
    {
        string jsonfilepath = string.Concat(Environment.CurrentDirectory, "/Data/students.json");
        var students = JsonReader<Student>.ReadFromJson(jsonfilepath);
        students.Add((Student)student);
        JsonWriter<Student>.WriteToJson(students, jsonfilepath);
    }
    public override string ToString()
    {
        return $"Id: {id} FörNamn: {FirstName} EfterNamn: {LastName} Email: {Email} PersonNummer {SocialSecurityNumber}";
    }
}

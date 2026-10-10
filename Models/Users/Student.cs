using System.Data.Common;

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
}

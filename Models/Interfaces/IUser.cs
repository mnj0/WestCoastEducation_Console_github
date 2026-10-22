using System;

namespace WestCoastEducation.Models.Interfaces;

public interface IUser
{
    string Id {get; }
    string FirstName {get; set;}
    string LastName {get; set;}
    string Email {get; set;}
    string SocialSecurityNumber {get; set;}
    string? PassWord {get; set;}
    string? Adress {get; set;}
    string? PostCode {get; set;}
    string? City {get; set;}
}

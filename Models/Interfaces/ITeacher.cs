using System;

namespace WestCoastEducation.Models.Interfaces;

public interface ITeacher : IUser
{
    string FieldOfKnowledge {get; set;}
    string Courses {get; set;}
    string? StartOfEmployment {get; set;}
    string? EndOfEmployment {get; set;}
}

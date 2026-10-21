using System;

namespace WestCoastEducation.Models.Interfaces;

public interface IEducationCordinator : ITeacher
{
    string StartOfEmployment {get; set;}
    string EndOfEmployment {get; set;}
}

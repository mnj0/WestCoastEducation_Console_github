using System;

namespace WestCoastEducation.Models.Interfaces;

public interface IEducationCordinator : ITeacher
{
    string OverSeeingCourses {get; set;}

}

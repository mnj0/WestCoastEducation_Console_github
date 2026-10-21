using System;

namespace WestCoastEducation.Models.Interfaces;

public interface ITeacher : IUser
{
    string FieldOfKnowledge {get; set;}
    string OverSeeingCourses {get; set;}
}

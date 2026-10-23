using System;

namespace WestCoastEducation.Models.Interfaces;

public interface ICourse
{
    string Id {get; }
    string Titel {get; set;}

    //Antal veckor i längd
    string HowManyWeeks {get; set;}
    string StartDate {get; set;}
    string EndDate {get; set;}
    string TypeOfCourse {get; set;}
}

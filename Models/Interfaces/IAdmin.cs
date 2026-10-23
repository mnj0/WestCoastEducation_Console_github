using System;

namespace WestCoastEducation.Models.Interfaces;

public interface IAdmin : IEducationCordinator
{
    public string AccesPass {get; set;}
}

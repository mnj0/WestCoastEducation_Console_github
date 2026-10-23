using System;
using System.Collections.Specialized;
using System.Data.Common;
using WestCoastEducation.Models.Interfaces;

namespace WestCoastEducation.Models.Methods;

public abstract class CourseSearch
{
   public static T? FindByIdOrTitel<T>(List<T> CourseJsonfile, string input) where T : class, ICourse
    {
        input = input.Trim();
        if (input.Length < 8)
        {
            return null;
        }

        string titel = input.Replace(" ", "");
        var idorssn = CourseJsonfile.Where(u => u.Id.ToString().StartsWith(input, StringComparison.OrdinalIgnoreCase) || (u.Titel ?? "").Replace(" ", "") == titel).ToList(); 

        return idorssn.Count == 1 ? idorssn[0] : null;
    }
}

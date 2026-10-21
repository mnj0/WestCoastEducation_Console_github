using System;
using System.Collections.Specialized;
using System.Data.Common;
using WestCoastEducation.Models.Interfaces;

namespace WestCoastEducation.Models.Methods;

public abstract class UserSearch
{
   public static T? FindByIdOrSocialSecurityNumber<T>(List<T> UserJsonfile, string input) where T : class, IUser
    {
        input = input.Trim();
        if (input.Length < 8)
        {
            return null;
        }

        string socialsecuritynumber = input.Replace("-", "");
        var idorssn = UserJsonfile.Where(u => u.Id.ToString().StartsWith(input, StringComparison.OrdinalIgnoreCase) || (u.SocialSecurityNumber ?? "").Replace("-", "") == socialsecuritynumber).ToList(); 

        return idorssn.Count == 1 ? idorssn[0] : null;
    }
}

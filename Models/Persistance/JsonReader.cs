using System;
using System.Runtime.CompilerServices;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace WestCoastEducation.Models.Persistance;

public class JsonReader<Placeholder> : JsonOptions
{

    public static List<Placeholder>ReadFromJson(string jsonfilepath)
    {
        try
        {
            string jsonfile = File.ReadAllText(jsonfilepath);
            if(!string.IsNullOrEmpty(jsonfile)|| string.IsNullOrWhiteSpace(jsonfile))
            {
                return JsonSerializer.Deserialize<List<Placeholder>>(jsonfile, ManuallySet_JsonOptions)!;
            }
            else
            {
                return [];
            }
        }
        catch (IOException ex)
        {
            throw new Exception(ex.Message);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}

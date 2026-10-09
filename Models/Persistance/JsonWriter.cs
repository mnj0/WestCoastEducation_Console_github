using System;
using System.Text.Json;

namespace WestCoastEducation.Models.Persistance;

public class JsonWriter<Placeholder> : JsonOptions
{
    public static void WriteToJson(List<Placeholder> YourList_ThatYouWantConvertedToJson, string jsonfilepath)
    {
        try
        {
            string jsonfile = JsonSerializer.Serialize(YourList_ThatYouWantConvertedToJson, ManuallySet_JsonOptions);
            File.WriteAllText(jsonfilepath, jsonfile);
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

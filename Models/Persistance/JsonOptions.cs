using System;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace WestCoastEducation.Models.Persistance;

public class JsonOptions
{
    protected static readonly JsonSerializerOptions ManuallySet_JsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
    };
}

namespace FinalProject.View;

using System.Text.Json;
using FinalProject.CharacterData;
using System.IO;
using System.Collections.Generic;
using System.Threading.Channels;
using FinalProject.data;

public class JsonReader
{
    private const string BackgroundsFilePath = "data/backgrounds.json";
    private const string TraitsFilePath = "data/traits.json";

    public static List<BackgroundData> LoadAllBackgrounds()
    {
        string jsonString_na = File.ReadAllText(BackgroundsFilePath);
        return JsonSerializer.Deserialize<List<BackgroundData>>(jsonString_na) ?? new List<BackgroundData>();
    }
    public static List<Trait> LoadAllTraits()
    {
        string jsonString_na = File.ReadAllText(TraitsFilePath);
        return JsonSerializer.Deserialize<List<Trait>>(jsonString_na) ?? new List<Trait>();
    }
}
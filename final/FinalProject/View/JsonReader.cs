namespace FinalProject.View;

using System.Text.Json;
using FinalProject.CharacterData;
using FinalProject.data;

public class JsonReader
{
    private const string BackgroundsFilePath = "data/backgrounds.json";
    private const string TraitsFilePath = "data/traits.json";
    private const string MoveRangeFilePath = "data/moveRanges.json";
    private const string DestiniesFilePath = "data/destinies.json";

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
    public static List<MoveRangeData> LoadMoveRanges()
    {
        string jsonString_na = File.ReadAllText(MoveRangeFilePath);
        return JsonSerializer.Deserialize<List<MoveRangeData>>(jsonString_na) ?? new List<MoveRangeData>();
    }
    public static List<Destiny> LoadAllDestinies()
    {
        string jsonString_na = File.ReadAllText(DestiniesFilePath);
        return JsonSerializer.Deserialize<List<Destiny>>(jsonString_na) ?? new List<Destiny>();
    }
}
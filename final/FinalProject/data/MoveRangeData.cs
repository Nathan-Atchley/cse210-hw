namespace FinalProject.data;
using System.Text.Json.Serialization;

public class MoveRangeData
{
    [JsonPropertyName("name")]
    public string Name_na { get; set; }

    [JsonPropertyName("range")]
    public string Range_na { get; set; }
}
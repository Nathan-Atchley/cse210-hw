namespace FinalProject.data;
using System.Text.Json.Serialization;

public class CharacterSaveData
{
    [JsonPropertyName("CharName_na")]
    public string CharName_na { get; set; }

    [JsonPropertyName("SpeciesName_na")]
    public string SpeciesName_na { get; set; }

    [JsonPropertyName("Level_na")]
    public int Level_na { get; set; }

    [JsonPropertyName("Experience_na")]
    public int Experience_na { get; set; }

    [JsonPropertyName("LevelPoints_na")]
    public int LevelPoints_na { get; set; }

    [JsonPropertyName("Destiny_na")]
    public string? Destiny_na { get; set; }

    [JsonPropertyName("ChosenPatron_na")]
    public string ChosenPatron_na { get; set; }

    [JsonPropertyName("Poke_na")]
    public int Poke_na { get; set; }

    [JsonPropertyName("BackgroundName_na")]
    public string BackgroundName_na { get; set; }

    [JsonPropertyName("AbilityName_na")]
    public string AbilityName_na { get; set; }

    [JsonPropertyName("Stats_na")]
    public Dictionary<string, int> Stats_na { get; set; } = new();

    [JsonPropertyName("Skills_na")]
    public Dictionary<string, int> Skills_na { get; set; } = new();

    [JsonPropertyName("SpecialistFields_na")]
    public List<string> SpecialistFields_na { get; set; } = new();

    [JsonPropertyName("Traits_na")]
    public List<string> Traits_na { get; set; } = new();

    [JsonPropertyName("Proficiencies_na")]
    public List<string> Proficiencies_na { get; set; } = new();

    [JsonPropertyName("EquippedMoveNames_na")]
    public List<string> EquippedMoveNames_na { get; set; } = new();

    [JsonPropertyName("Inventory_na")]
    public List<string> Inventory_na { get; set; } = new();
}
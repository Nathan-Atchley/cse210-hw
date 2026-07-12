namespace FinalProject.API;
using FinalProject.View;
using FinalProject.API;
using FinalProject.CharacterData;
public class PokemonData
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<string> Types { get; set; } = new List<string>();
    public Dictionary<string, int> BaseStats { get; set; } = new Dictionary<string, int>();
    public Dictionary<string, string> Abilities { get; set; } = new Dictionary<string, string>();
}
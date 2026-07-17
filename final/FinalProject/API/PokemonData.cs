namespace FinalProject.API;
using FinalProject.CharacterData;
public class PokemonData
{
    public int Id_na { get; set; }
    public string Name_na { get; set; }
    public List<string> Types_na { get; set; } = new List<string>();
    public Dictionary<string, int> BaseStats_na { get; set; } = new Dictionary<string, int>();
    public Dictionary<string, string> Abilities_na { get; set; } = new Dictionary<string, string>();
    public List<Move> Moves_na { get; set; } = new List<Move>();
}
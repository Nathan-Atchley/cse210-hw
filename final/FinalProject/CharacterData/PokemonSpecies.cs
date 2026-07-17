namespace FinalProject.CharacterData;
using FinalProject.View;
using FinalProject.API;
public class PokemonSpecies
{
    public string SpeciesName_na { get ; }
    public List<String> Types_na { get ; }
    public List<Ability> AvailableAbilities_na { get ; private set ;}
    public Dictionary<string, int> BaseStats_na { get ; private set ; }
    public List<Move> Moves_na { get ; private set ; }

    public PokemonSpecies(PokemonData data_na) {
        SpeciesName_na = data_na.Name_na;
        Types_na = [.. data_na.Types_na];

        AvailableAbilities_na = new List<Ability>{};

        foreach (var ability_na in data_na.Abilities_na)
        {
            string abilityName_na = ability_na.Key;
            string abilityDescription_na = ability_na.Value;
            Ability newAbility_na = new Ability(abilityName_na, abilityDescription_na);
            AvailableAbilities_na.Add(newAbility_na);
        }

        BaseStats_na = new Dictionary<string, int>{};

        foreach (var stat_na in data_na.BaseStats_na)
        {
            BaseStats_na.Add(stat_na.Key, stat_na.Value);
        }

        Moves_na = [.. data_na.Moves_na];
    }
}
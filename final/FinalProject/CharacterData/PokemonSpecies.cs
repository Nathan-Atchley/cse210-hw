namespace FinalProject.CharacterData;
using FinalProject.View;
using FinalProject.API;
using FinalProject.CharacterData;
public class PokemonSpecies
{
    public string SpeciesName { get ; }
    public List<String> Types { get ; }
    public List<Ability> AvailableAbilities { get ; private set ;}
    public Dictionary<string, int> BaseStats { get ; private set ; }

    public PokemonSpecies(PokemonData data_na) {
        SpeciesName = data_na.Name;
        Types = [.. data_na.Types];

        AvailableAbilities = new List<Ability>{};

        foreach (var ability_na in data_na.Abilities)
        {
            string abilityName_na = ability_na.Key;
            string abilityDescription_na = ability_na.Value;
            Ability newAbility_na = new Ability(abilityName_na, abilityDescription_na);
            AvailableAbilities.Add(newAbility_na);
        }

        BaseStats = new Dictionary<string, int>{};

        foreach (var stat_na in data_na.BaseStats)
        {
            BaseStats.Add(stat_na.Key, stat_na.Value);
        }
    }
}
namespace FinalProject.CharacterData;
using FinalProject.View;
using FinalProject.API;
using FinalProject.CharacterData;
using System.ComponentModel;
using CsvHelper;

public class Character
{
    public string CharName_na { get ; }
    public int Level_na { get ; }
    public int Experience_na { get ; }
    public int LevelPoints_na { get ; }
    public PokemonSpecies Species_na { get ; }
    public StatBlock Stats_na { get ; private set ;}
    public Dictionary<string, int> StatArray_na { get ; }
    public Background ChosenBackground_na { get ; }
    public Destiny ChosenDestiny_na { get ; private set ; }
    public Ability ActiveAbility_na { get ; }
    public List<Trait> SelectedTraits_na { get ; }
    public List<Move> EquippedMoves_na { get ; private set ; }
    public Inventory EquipmentLog_na { get ; }

    public Character(string name_na, PokemonSpecies species_na, Dictionary<string, int> statArray_na, Background chosenBackground_na, Ability activeAbility_na, Trait trait_na)
    {
        SelectedTraits_na = new List<Trait>();
        EquippedMoves_na = new List<Move>();

        CharName_na = name_na;
        Species_na = species_na;
        Stats_na = null;
        ChosenBackground_na = chosenBackground_na;
        ActiveAbility_na = activeAbility_na;
        SelectedTraits_na.Add(trait_na);
        StatArray_na = statArray_na;
        
        Level_na = 1;
        Experience_na = 0;
        LevelPoints_na = 0;
        CalculateInitialStats();
        EquipmentLog_na = new Inventory();
    }

    public void CalculateInitialStats()
    {
        int rawHp_na = Species_na.BaseStats.GetValueOrDefault("HP", 0);
        int rawAtk_na = Species_na.BaseStats.GetValueOrDefault("ATK", 0);
        int rawDef_na = Species_na.BaseStats.GetValueOrDefault("DEF", 0);
        int rawSpAtk_na = Species_na.BaseStats.GetValueOrDefault("SPATK", 0);
        int rawSpDef_na = Species_na.BaseStats.GetValueOrDefault("SPDEF", 0);
        int rawSpeed_na = Species_na.BaseStats.GetValueOrDefault("SPD", 0);

        int speed_na = StatConverter.GetSpeed(rawSpeed_na);
        int atk_na = StatConverter.GetStatBonus(rawAtk_na) + StatArray_na["ATK"];
        int def_na = StatConverter.GetStatBonus(rawDef_na) + StatArray_na["DEF"];
        int spAtk_na = StatConverter.GetStatBonus(rawSpAtk_na) + StatArray_na["SPATK"];
        int spDef_na = StatConverter.GetStatBonus(rawSpDef_na) + StatArray_na["SPDEF"];

        int stabBasic_na = StatConverter.GetStabBasic(Level_na);

        Stats_na = new StatBlock(rawHp_na, atk_na, def_na, spAtk_na, spDef_na, speed_na, stabBasic_na, stabBasic_na);
    }

    public void AddExperience(int experienceAdded_na)
    {
        // Will add exp to Experience_na, and check to see if
        // it is enough to level up
    }

    public void LevelUp()
    {
        // Will increase level variable, add a Level Point,
        // check for new moves (need to add move list to PokemonSpecies), and prompt for a destiny at lvl 5
        // also will check for evolution (need to add that to PokemonSpecies)
    }

    public void SwapMoves()
    {
        // Will be used to pull all available moves from the PokemonSpecies
        // and add the chosen 4 to EquippedMoves_na
    }
}
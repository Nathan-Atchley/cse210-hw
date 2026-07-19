namespace FinalProject.CharacterData;
using FinalProject.View;

public class Character
{
    public string CharName_na { get ; }
    public int Level_na { get ; private set ; }
    public int Experience_na { get ; private set ; }
    public int LevelPoints_na { get ; private set ; }
    public PokemonSpecies Species_na { get ; }
    public StatBlock Stats_na { get ; private set ; }
    public Dictionary<string, int> StatArray_na { get ; }
    public SkillSheet Skills_na { get ; private set ; }
    public List<string> Proficiencies_na { get ; private set ; }
    public Background ChosenBackground_na { get ; }
    public Destiny ChosenDestiny_na { get ; private set ; }
    public Ability ActiveAbility_na { get ; }
    public List<Trait> SelectedTraits_na { get ; }
    public Move EggMove_na { get ; }
    public List<Move> EquippedMoves_na { get ; set ; }
    public Inventory EquipmentLog_na { get ; }

    public bool NeedsDestiny => Level_na ==5;
    public bool NeedsLevelup_na => Experience_na >= Level_na * 100;
    public bool NeedsSpecialistField => Level_na == 5 || Level_na == 10 || Level_na == 15 || Level_na == 20;

    public Character(string name_na, PokemonSpecies species_na, Dictionary<string, int> statArray_na, Background chosenBackground_na, Ability activeAbility_na, Trait trait_na, SkillSheet skills_na)
    {
        SelectedTraits_na = new List<Trait>();
        EquippedMoves_na = new List<Move>();
        Proficiencies_na = new List<string>();
        Skills_na = skills_na;

        CharName_na = name_na;
        Species_na = species_na;
        Stats_na = null;
        ChosenBackground_na = chosenBackground_na;
        ActiveAbility_na = activeAbility_na;
        StatArray_na = statArray_na;
        
        Level_na = 1;
        Experience_na = 0;
        LevelPoints_na = 0;
        CalculateInitialStats();
        EquipmentLog_na = new Inventory();
        
        AddTrait(trait_na);
        AddTrait(chosenBackground_na.GrantedTrait_na);
    }
    public Character(string name_na, PokemonSpecies species_na, int level_na, int experience_na, int levelPoints_na, Dictionary<string, int> statModifiers_na, Background chosenBackground_na, Ability activeAbility_na, SkillSheet skills_na, List<Trait> traits_na,int poke_na)
    {
        CharName_na = name_na;
        Species_na = species_na;
        Level_na = level_na;
        Experience_na = experience_na;
        LevelPoints_na = levelPoints_na;
        
        ChosenBackground_na = chosenBackground_na;
        ActiveAbility_na = activeAbility_na;
        Skills_na = skills_na;
        
        StatArray_na = statModifiers_na ?? new Dictionary<string, int>();
        SelectedTraits_na = new List<Trait>();
        EquippedMoves_na = new List<Move>();
        Proficiencies_na = new List<string>();
        
        CalculateInitialStats();
        
        if (traits_na != null)
        {
            foreach (var trait in traits_na)
            {
                AddTrait(trait);
            }
        }

        EquipmentLog_na = new Inventory();
        if (EquipmentLog_na != null)
        {
            EquipmentLog_na.Poke_na = poke_na;
        }
    }

    public void CalculateInitialStats()
    {
        int rawHp_na = Species_na.BaseStats_na.GetValueOrDefault("hp", 0);
        int rawAtk_na = Species_na.BaseStats_na.GetValueOrDefault("attack", 0);
        int rawDef_na = Species_na.BaseStats_na.GetValueOrDefault("defense", 0);
        int rawSpAtk_na = Species_na.BaseStats_na.GetValueOrDefault("special-attack", 0);
        int rawSpDef_na = Species_na.BaseStats_na.GetValueOrDefault("special-defense", 0);
        int rawSpeed_na = Species_na.BaseStats_na.GetValueOrDefault("speed", 0);

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
        Experience_na += experienceAdded_na;
    }

    public void LevelUp()
    {
        Experience_na -= Level_na * 100;
        Level_na += 1;
        LevelPoints_na += 1 + 2 * ((int)Math.Floor(Level_na / 5.0));
        // prompt for a destiny at lvl 5
        // also will check for evolution (need to add that to PokemonSpecies)
    }

    public void SpendLevelPoint(int pointsCost_na)
    {
        if (LevelPoints_na >= pointsCost_na)
        {
            LevelPoints_na -= pointsCost_na;
        }
    }

    public void AddProficiency(string proficiency_na)
    {
        Proficiencies_na.Add(proficiency_na);
    }

    public bool HasProficiency(string proficiency_na)
    {
        if (Proficiencies_na.Contains(proficiency_na)) 
            return true;
        else return false;
    }

    public void AddTrait(Trait trait_na)
    {
        if (!SelectedTraits_na.Any(t_na => t_na.Name_na.Equals(trait_na.Name_na, StringComparison.OrdinalIgnoreCase)))
        {
            SelectedTraits_na.Add(trait_na);
            trait_na.ApplyToCharacter(this);
        }
    }
    public void AddDestiny(Destiny destiny_na)
    {
        ChosenDestiny_na = destiny_na;
    }
    public void SwapMoves()
    {
        EquippedMoves_na.Clear();
        List<Move> newMoves_na = UserAssignmentHandler.ChooseMoves(Species_na, Level_na);
        foreach (Move move_na in newMoves_na)
        {
            EquippedMoves_na.Add(move_na);
        }
    }
}
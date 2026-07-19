namespace FinalProject.View;
using FinalProject.API;
using FinalProject.CharacterData;
using FinalProject.data;
using System.Globalization;
public static class ViewPrint
{
    public static async Task<Character> MakeCharacter(DataStorage allData_na)
    {
        string name_na = GrabInput.String("Enter Character name: ");
        CharacterData.PokemonSpecies species_na = null;
        while(species_na == null)
        {
            string pkmnName_na = GrabInput.String("Enter your chosen Pokemon: ");
            species_na = await PullPokemonData(pkmnName_na, allData_na);
        }

        Dictionary<string, int> statArray_na = StatAssignmentHandler.AssignModifiersToStats(StatAssignmentHandler.GetModifierArray());
        SkillSheet skillSheet_na = UserAssignmentHandler.GenerateSkillSheet();
        Trait chosenTrait_na = UserAssignmentHandler.GetBeginnerTrait(allData_na);
        Background chosenBackground_na = UserAssignmentHandler.GetBackground(allData_na);
        Ability activeAbility_na = UserAssignmentHandler.GetAbility(species_na);
        List<Move> startingMoves_na = UserAssignmentHandler.ChooseMoves(species_na);

        Character playerCharacter_na = new Character(name_na, species_na, statArray_na, chosenBackground_na, activeAbility_na, chosenTrait_na, skillSheet_na);

        string chosenProficiency_na = UserAssignmentHandler.ChooseProficiency(playerCharacter_na);

        playerCharacter_na.AddProficiency(chosenProficiency_na);

        foreach (Move move_na in startingMoves_na)
        {
            playerCharacter_na.EquippedMoves_na.Add(move_na);
        }

        return playerCharacter_na;
    }

    public static void PrintCharacter(Character character_na)
    {
        Console.Clear();
        Console.WriteLine("\n==================================================");
        Console.WriteLine($"   CHARACTER SHEET: {character_na.CharName_na.ToUpper()}");
        Console.WriteLine("==================================================");
        Console.WriteLine($" Species:    {CapitalizeWord(character_na.Species_na.SpeciesName_na)}");
        Console.WriteLine($" Level:      {character_na.Level_na} (XP: {character_na.Experience_na} / {character_na.Level_na * 100})");
        Console.WriteLine($" LP:         {character_na.LevelPoints_na}");
        Console.WriteLine($" Background: {character_na.ChosenBackground_na?.Name_na ?? "None"}");
        Console.WriteLine($" Ability:    {CapitalizeWord(character_na.ActiveAbility_na?.Name_na ?? "None")}");

        if (character_na.SelectedTraits_na != null && character_na.SelectedTraits_na.Count > 0)
        {
            Console.WriteLine(" Traits:     " + string.Join(", ", character_na.SelectedTraits_na.ConvertAll(t => t.Name_na)));
        }

        if (character_na.Proficiencies_na != null && character_na.Proficiencies_na.Count > 0)
        {
            Console.WriteLine(" Proficiencies: " + string.Join(", ", character_na.Proficiencies_na));
        }
        if (character_na.Level_na >= 5 && character_na.ChosenDestiny_na != null)
        {
            var destiny_na = character_na.ChosenDestiny_na;
            Console.WriteLine("\n------------------- DESTINY --------------------");
            Console.WriteLine($" Destiny:    {destiny_na.Name_na}");
            
            if (!string.IsNullOrEmpty(destiny_na.PatronChoice_na))
            {
                Console.WriteLine($" Patron:     {destiny_na.PatronChoice_na}");
            }

            Console.WriteLine($"\n [Lv 5 Feature] {destiny_na.Lv5FeatureName_na}");
            Console.WriteLine($"   {destiny_na.Lv5FeatureDesc_na}");

            if (character_na.Level_na >= 15)
            {
                Console.WriteLine($"\n [Lv 15 Feature] {destiny_na.Lv15FeatureName_na}");
                Console.WriteLine($"   {destiny_na.Lv15FeatureDesc_na}");
            }
        }
        
        if (character_na.Stats_na != null)
        {
            PrintCoreStats(character_na);
            int stab_na = character_na.Stats_na.GetValue("STAB");
            int basic_na = character_na.Stats_na.GetValue("BASIC");
            Console.WriteLine($" STAB:  {stab_na,-3} | BASIC: {basic_na,-2}");
        }

        if (character_na.Skills_na != null)
        {
            PrintSkillList(character_na);
        }

        Console.WriteLine("\n---------------- EQUIPPED MOVES ----------------");
        if (character_na.EquippedMoves_na == null || character_na.EquippedMoves_na.Count == 0)
        {
            Console.WriteLine(" No moves equipped.");
        }
        else
        {
            for (int i = 0; i < character_na.EquippedMoves_na.Count; i++)
            {
                Move move_na = character_na.EquippedMoves_na[i];
                PrintMoveDetails(i + 1, move_na);
            }
        }

        Console.WriteLine("==================================================\n");
    }
    public static void PrintCoreStats(Character character_na)
    {
            Console.WriteLine("\n------------------ STAT BLOCK ------------------");
            int hp_na = character_na.Stats_na.GetValue("HP");
            int speed_na = character_na.Stats_na.GetValue("SPD");
            int atk_na = character_na.Stats_na.GetValue("ATK");
            int def_na = character_na.Stats_na.GetValue("DEF");
            int spAtk_na = character_na.Stats_na.GetValue("SPATK");
            int spDef_na = character_na.Stats_na.GetValue("SPDEF");

            Console.WriteLine($" HP:    {hp_na,-3} | Speed: {speed_na,-2}");
            Console.WriteLine($" ATK:   {atk_na,-3} | DEF:   {def_na,-2}");
            Console.WriteLine($" SPATK: {spAtk_na,-3} | SPDEF: {spDef_na,-2}");
    }
    public static void PrintSkillList(Character character_na)
    {
        
        Console.WriteLine("\n----------------- SKILL LIST ------------------");
        int Athletics_na = character_na.Skills_na.GetValue("Athletics");
        int Craft_na = character_na.Skills_na.GetValue("Craft");
        int Endurance_na = character_na.Skills_na.GetValue("Endurance");
        int Finesse_na = character_na.Skills_na.GetValue("Finesse");
        int Medicine_na = character_na.Skills_na.GetValue("Medicine");
        int Perception_na = character_na.Skills_na.GetValue("Perception");
        int Performance_na = character_na.Skills_na.GetValue("Performance");
        int Persuasion_na = character_na.Skills_na.GetValue("Persuasion");
        int SpecialistKnowledge_na = character_na.Skills_na.GetValue("Special Knowledge");
        int Stealth_na = character_na.Skills_na.GetValue("Stealth");
        int Survival_na = character_na.Skills_na.GetValue("Survival");

        Console.WriteLine($" Athletics:     {Athletics_na,-2} | Craft:      {Craft_na,-2}");
        Console.WriteLine($" Endurance:     {Endurance_na,-2} | Finesse:    {Finesse_na,-2}");
        Console.WriteLine($" Medicine:      {Medicine_na,-2} | Perception: {Perception_na,-2}");
        Console.WriteLine($" Performance:   {Performance_na,-2} | Persuasion: {Persuasion_na,-2}");
        Console.WriteLine($" Sp. Knowledge: {SpecialistKnowledge_na} | Stealth:    {Stealth_na}");
        Console.WriteLine($" Survival:      {Survival_na}");
        Console.WriteLine($"\n Sp. Knowledge Fields: {string.Join(", ", character_na.Skills_na.SpecialistKnowledge_na)}");
    }
    public static void PrintMoveDetails(int slotIndex_na, Move move_na)
    {
        string powerStr = move_na.Power_na > 0 ? move_na.Power_na.ToString() : "--";
        string accStr = move_na.Accuracy_na > 0 ? $"{move_na.Accuracy_na}%" : "--";

        Console.WriteLine($" [{slotIndex_na}] {move_na.Name_na.ToUpper()}");
        Console.WriteLine($"     Type: {CapitalizeWord(move_na.Type_na),-10} | Class: {CapitalizeWord(move_na.DamageClass_na),-10} | PP: {move_na.PP_na}");
        Console.WriteLine($"     Power: {powerStr,-9} | Acc: {accStr,-12} | Range: {move_na.Range_na}");
        if (!string.IsNullOrWhiteSpace(move_na.Description_na))
        {
            Console.WriteLine($"     Desc: {move_na.Description_na}");
        }
        Console.WriteLine();
    }
    static async Task<CharacterData.PokemonSpecies> PullPokemonData(string pkmnSpecies_na, DataStorage allData_na)
    {
        return await ConsoleSpinner.RunWithLoadingAsync(
            $"Fetching {pkmnSpecies_na}'s data from PokeAPI",
            async () =>
            {
                try
                {
                    using (IPokeApi apiService = new PokeApi())
                    {
                        CharacterData.PokemonSpecies pkmn_na = await apiService.GetPokemonDataAsync(pkmnSpecies_na, allData_na);
                        return pkmn_na;
                    }    
                }
                catch (HttpRequestException)
                {
                    Console.WriteLine($"\nError: Could not find Pokemon '{pkmnSpecies_na}'. Try again.");
                    return null;
                }
                catch (Exception error_na)
                {
                    Console.WriteLine($"An unexpected error occurred: {error_na.Message}");
                    return null;
                }

                
            }
        );
    }
    public static string CapitalizeWord(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return string.Empty;
        
        // Replace hyphens with spaces first if desired, or leave as-is
        string formatted = input.Replace('-', ' ');
        return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(formatted.ToLower());
    }


}
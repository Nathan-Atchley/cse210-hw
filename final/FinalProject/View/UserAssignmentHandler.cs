namespace FinalProject.View;

using FinalProject.CharacterData;
using FinalProject.data;

public enum ProficiencesList_na {
    

}
public static class UserAssignmentHandler
{
    public static List<Move> ChooseMoves(PokemonSpecies pokemonSpecies_na, int characterLevel_na = 1)
    {
        List<Move> chosenMoves_na = new List<Move>();
        List<Move> availableMoves_na = pokemonSpecies_na.Moves_na
            .Where(move_na => move_na.LearnMethod_na == "level-up" && move_na.Prerequisites_na <= characterLevel_na)
            .OrderBy(move_na => move_na.Prerequisites_na)
            .ToList();
        if (availableMoves_na.Count == 0)
        {
            availableMoves_na = pokemonSpecies_na.Moves_na
                .Where(move_na => move_na.LearnMethod_na == "level-up" && move_na.Prerequisites_na == 1)
                .ToList();
        }

        Console.WriteLine("\nChoose the 4 moves for your Pokemon: ");
        int maxMoves_na = Math.Min(4, availableMoves_na.Count);
        for (int i = 0; i < maxMoves_na; i++)
        {
            Console.WriteLine("\nAvailable choices:");
            for (int j = 0; j < availableMoves_na.Count; j++)
            {
                var move_na = availableMoves_na[j];
                Console.WriteLine($" [{j + 1}] {ViewPrint.CapitalizeWord(move_na.Name_na)} (Lv {move_na.Prerequisites_na}) - {move_na.Type_na} | {move_na.DamageClass_na} | Power: {move_na.Power_na} | Acc: {move_na.Accuracy_na}");
            }

            int userChoice_na = GrabInput.IntInRange($"Select move {i + 1} of {maxMoves_na} (0 to finish): ", 0, availableMoves_na.Count);
            if (userChoice_na == 0) break;

            Move chosenMove = availableMoves_na[userChoice_na - 1];
            chosenMoves_na.Add(chosenMove);
            availableMoves_na.RemoveAt(userChoice_na - 1);
        }

        return chosenMoves_na;
    }
    public static Ability GetAbility(PokemonSpecies pokemonSpecies_na)
    {
        Console.WriteLine($"\nPlease choose your pokemon's ability: ");
        int i = 0;
        foreach (Ability ability_na in pokemonSpecies_na.AvailableAbilities_na)
        {
            i++;
            Console.WriteLine($" {i}. {ability_na.Name_na}\n      Description: {ability_na.Description_na}");
        }
        int abilityChoice_na = GrabInput.Int($"Enter your choice (1-{i}): ");
        while (abilityChoice_na < 1 || abilityChoice_na > i)
        {
            abilityChoice_na = GrabInput.Int($"Invalid selection. Please enter your choice (1-{i}): ");
        }
        return pokemonSpecies_na.AvailableAbilities_na[abilityChoice_na - 1];
    }
    public static Background GetBackground(DataStorage allData_na)
    {
        Console.WriteLine($"\nPlease choose a Background from the list:");
        List<Background> backgrounds_na = allData_na.GetAllBackgrounds();

        int i = 0;
        foreach (Background background_na in backgrounds_na)
        {
            i++;
            Console.WriteLine($" {i}. {background_na.Name_na}\n      Description: {background_na.Description_na}");
        }

        int backgroundChoice = GrabInput.Int($"Enter the number of your Background choice (1-{i})");
        while (backgroundChoice < 1 || backgroundChoice > i)
        {
            backgroundChoice = GrabInput.Int($"Invalid selection. Please enter your choice (1-{i}): ");
        }

        return backgrounds_na[backgroundChoice - 1];
    }
    public static Trait GetBeginnerTrait(DataStorage allData_na)
    {
        Console.WriteLine($"\nPlease choose a Trait from the list:");
        List<Trait> traits_na = allData_na.GetAllBeginnerTraits();

        int i = 0;
        foreach (Trait trait_na in traits_na)
        {
            i++;
            Console.WriteLine($"\n {i}. {trait_na.Name_na}\n      Description: {trait_na.Description_na}");
        }

        int traitChoice = GrabInput.IntInRange($"\nEnter the number of your Trait choice (1-{i})", 1, i);

        return traits_na[traitChoice - 1];
    }
    public static Trait GetAvailableTraits(DataStorage allData_na, Character character_na)
    {
        Console.WriteLine($"\nPlease choose a Trait from the list:");
        List<Trait> traits_na = allData_na.GetAllAvailableTraits(character_na);

        int i = 0;
        foreach (Trait trait_na in traits_na)
        {
            i++;
            Console.WriteLine($"\n {i}. {trait_na.Name_na}\n      Description: {trait_na.Description_na}");
        }

        int traitChoice = GrabInput.IntInRange($"\nEnter the number of your Trait choice (1-{i}): ", 1, i);

        return traits_na[traitChoice - 1];
    }
    public static SkillSheet GenerateSkillSheet()
    {
        SkillSheet skills_na = new SkillSheet();
        Random rng_na = new Random();
        List<int> rolledValues_na = new List<int>();

        List<string> availableSkills_na = new List<string>
        {
            "Athletics", "Craft", "Endurance", "Finesse", "Medicine", 
            "Perception", "Performance", "Persuasion", "Special Knowledge", 
            "Stealth", "Survival"
        };

        bool userChoice_na = GrabInput.Bool("\nDo you already have your skills rolled (3d6 six times)? ");
        if (!userChoice_na)
        {
            // 1. Roll 3d6 * 5 six times
            for (int i = 0; i < 6; i++)
            {
                int roll_na = (rng_na.Next(1, 7) + rng_na.Next(1, 7) + rng_na.Next(1, 7)) * 5;
                rolledValues_na.Add(roll_na);
            }

        }
        else
        {
            for (int i = 0; i < 6; i++)
            {
                int roll_na = GrabInput.Int($" {i+1}. Please enter the number you rolled: ") * 5;
                rolledValues_na.Add(roll_na);
            }
        }

        Console.WriteLine("\n--- Skill Rolling ---");
        Console.WriteLine($"You rolled the following 6 skill scores: {string.Join(", ", rolledValues_na)}"); 
        Console.WriteLine("Assign these scores to 6 skills. Unassigned skills will remain at 15.\n");

        // 2. Assign rolled scores to chosen skills
        foreach (int val_na in rolledValues_na)
        {
            Console.WriteLine($"\nRemaining available skills:\n {string.Join(", ", availableSkills_na)}");
            Console.WriteLine($"Assign score: {val_na}");

            string chosenSkill_na = "";
            bool validChoice_na = false;

            while (!validChoice_na)
            {
                string input_na = GrabInput.String("Enter skill name: ").Trim();
                
                // Match input case-insensitively with available skills
                chosenSkill_na = availableSkills_na.FirstOrDefault(s => s.Equals(input_na, StringComparison.OrdinalIgnoreCase));

                if (chosenSkill_na != null)
                {
                    skills_na.SetValue(chosenSkill_na, val_na);
                    availableSkills_na.Remove(chosenSkill_na);
                    validChoice_na = true;
                }
                else
                {
                    Console.WriteLine("Invalid skill name or skill already assigned. Please choose from the remaining list.");
                }
            }
        }

        // 3. Prompt for starting Field of Expertise
        string field_na = GrabInput.String("\nEnter your starting Specialist Knowledge Field of Expertise (e.g., Astronomy, Occult, Dungeons): ");
        skills_na.AddSpecialistKnowledge(field_na);

        return skills_na;
    }

    public static void AddExperience(int expAmount_na, Character player_na, DataStorage allData_na)
    {
        player_na.AddExperience(expAmount_na);
        while (player_na.NeedsLevelup_na)
        {
            ProcessLevelUp(player_na, allData_na);
        }
    }
    public static void ProcessLevelUp(Character player_na, DataStorage allData_na)
    {
        player_na.LevelUp();
        if (player_na.NeedsSpecialistField)
        {
            string newSpKnwl_na = GrabInput.String($"Level {player_na.Level_na} reached! Enter a new Specialist Knowledge Field of Expertise: ");
            player_na.Skills_na.AddSpecialistKnowledge(newSpKnwl_na);
        }
        if (player_na.NeedsDestiny)
        {
            Destiny chosenDestiny_na = ChooseDestiny(allData_na, player_na);
            player_na.AddDestiny(chosenDestiny_na);
        }
        player_na.SwapMoves();
    }
    public static Destiny ChooseDestiny(DataStorage allData_na, Character player_na)
    {
        Console.WriteLine("\n--- Choose Your Destiny ---");
        List<Destiny> availableDestinies_na = allData_na.GetAllDestinies();

        // 1. Display available destinies
        for (int i = 0; i < availableDestinies_na.Count; i++)
        {
            var dest_na = availableDestinies_na[i];
            Console.WriteLine($"\n [{i + 1}] {dest_na.Name_na}");
            Console.WriteLine($"     \"{dest_na.FlavorText_na}\"");
            Console.WriteLine($"     {dest_na.Description_na}");
            Console.WriteLine($"     Skill Options: {string.Join(" or ", dest_na.BonusSkills_na)} | Proficiency: {dest_na.BonusProficiency_na}");
        }

        int choice_na = GrabInput.IntInRange($"\nEnter the number of your Destiny choice (1-{availableDestinies_na.Count}): ", 1, availableDestinies_na.Count);
        Destiny baseDestiny_na = availableDestinies_na[choice_na - 1];

        string? selectedPatron_na = null;
        if (baseDestiny_na.PatronOptions_na != null && baseDestiny_na.PatronOptions_na.Count > 0)
        {
            Console.WriteLine($"\n--- Choose Your Mythical Patron for the Mythbound Destiny ---");
            for (int i = 0; i < baseDestiny_na.PatronOptions_na.Count; i++)
            {
                var patron_na = baseDestiny_na.PatronOptions_na[i];
                Console.WriteLine($" [{i + 1}] {string.Join(" / ", patron_na.Pokemon_na)}: {patron_na.Effect_na}");
            }

            int patronChoice_na = GrabInput.IntInRange($"Select a patron option (1-{baseDestiny_na.PatronOptions_na.Count}): ", 1, baseDestiny_na.PatronOptions_na.Count);
            var chosenPatron_na = baseDestiny_na.PatronOptions_na[patronChoice_na - 1];

            if (chosenPatron_na.Pokemon_na.Count > 1)
            {
                Console.WriteLine("\nWhich specific mythical patron touched your life?");
                for (int i = 0; i < chosenPatron_na.Pokemon_na.Count; i++)
                {
                    Console.WriteLine($" [{i + 1}] {chosenPatron_na.Pokemon_na[i]}");
                }
                int pIdx = GrabInput.IntInRange($"Select patron (1-{chosenPatron_na.Pokemon_na.Count}): ", 1, chosenPatron_na.Pokemon_na.Count);
                selectedPatron_na = chosenPatron_na.Pokemon_na[pIdx - 1];
            }
            else
            {
                selectedPatron_na = chosenPatron_na.Pokemon_na[0];
            }
        }

        List<string> chosenSkills_na = new List<string>();
        Console.WriteLine($"\n--- Choose Skill Bonus for {baseDestiny_na.Name_na} ---");
        for (int i = 0; i < baseDestiny_na.BonusSkills_na.Count; i++)
        {
            int currentVal = player_na.Skills_na.GetValue(baseDestiny_na.BonusSkills_na[i]);
            Console.WriteLine($" [{i + 1}] {baseDestiny_na.BonusSkills_na[i]} (Current: {currentVal})");
        }

        int userChoice_na = GrabInput.IntInRange($"Select skill to increase (1-{baseDestiny_na.BonusSkills_na.Count}): ", 1, baseDestiny_na.BonusSkills_na.Count);
        string selectedSkill_na = baseDestiny_na.BonusSkills_na[userChoice_na - 1];
        int currentVal_na = player_na.Skills_na.GetValue(selectedSkill_na);

        if (currentVal_na >= 95)
        {
            Console.WriteLine($"\n{selectedSkill_na} is already at 95. You get +10 to a different skill of your choice!");
            string altSkill_na = PromptSkillChoice(player_na, excludeSkill_na: selectedSkill_na, maxAllowedScore: 85);
            chosenSkills_na.Add(altSkill_na);
        }
        else if (currentVal_na == 90)
        {
            Console.WriteLine($"\n{selectedSkill_na} is at 90. It will receive +5 to hit 95, and you may select another skill to receive the remaining +5.");
            chosenSkills_na.Add(selectedSkill_na);

            string altSkill_na = PromptSkillChoice(player_na, excludeSkill_na: selectedSkill_na, maxAllowedScore: 90);
            chosenSkills_na.Add(altSkill_na);
        }
        else
        {
            chosenSkills_na.Add(selectedSkill_na);
        }

        Destiny finalDestiny_na = new Destiny(
            baseDestiny_na.Name_na,
            baseDestiny_na.Description_na,
            baseDestiny_na.FlavorText_na,
            baseDestiny_na.BonusSkills_na,
            baseDestiny_na.BonusProficiency_na,
            baseDestiny_na.Lv5FeatureName_na,
            baseDestiny_na.Lv5FeatureDesc_na,
            baseDestiny_na.Lv15FeatureName_na,
            baseDestiny_na.Lv15FeatureDesc_na,
            chosenSkills_na,
            baseDestiny_na.PatronOptions_na,
            selectedPatron_na,
            baseDestiny_na.Prerequisites_na
        );

        finalDestiny_na.ApplyToCharacter(player_na);

        return finalDestiny_na;
    }

    private static string PromptSkillChoice(Character player_na, string excludeSkill_na, int maxAllowedScore)
    {
        List<string> eligibleSkills_na = player_na.Skills_na.GetAllValues()
            .Where(kvp => kvp.Value <= maxAllowedScore && !kvp.Key.Equals(excludeSkill_na, StringComparison.OrdinalIgnoreCase))
            .Select(kvp => kvp.Key)
            .ToList();

        Console.WriteLine("\nSelect an eligible skill from the list below:");
        for (int i = 0; i < eligibleSkills_na.Count; i++)
        {
            int currentVal_na = player_na.Skills_na.GetValue(eligibleSkills_na[i]);
            Console.WriteLine($" [{i + 1}] {eligibleSkills_na[i]} (Current: {currentVal_na})");
        }

        int userChoice_na = GrabInput.IntInRange($"Select skill (1-{eligibleSkills_na.Count}): ", 1, eligibleSkills_na.Count);
        return eligibleSkills_na[userChoice_na - 1];
    }

    public static string ChooseProficiency(Character player_na)
    {
        List<string> proficiencies_na = new List<string>
        {
            "Herbalist's Kit",
            "Medical Kit",
            "Archaeology/Forensics Kit",
            "Camping Gear",
            "Cooking Equipment",
            "Artisan Tools",
            "Trapmaking Tools",
            "Musical Instrument",
            "Thieves' Tools",
            "Gaming Kit",
            "Improvised Weaponry",
            "Melee Weaponry",
            "Ranged Weaponry"
        };
        List<string> availableProfieciences_na = new List<string>();
        foreach (string proficiency_na in proficiencies_na)
        {
            if (!player_na.Proficiencies_na.Contains(proficiency_na))
            {
                availableProfieciences_na.Add(proficiency_na);
            }
        }

        Console.WriteLine("\nPlease choose a Proficiency:");
        for (int i = 0; i < availableProfieciences_na.Count; i++)
        {
            Console.WriteLine($" [{i + 1}] {availableProfieciences_na[i]}");
        }

        int choice_na = GrabInput.IntInRange($"Select a proficiency (1-{availableProfieciences_na.Count}): ", 1, availableProfieciences_na.Count);

        return availableProfieciences_na[choice_na - 1];
    }
}
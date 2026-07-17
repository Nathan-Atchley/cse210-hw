namespace FinalProject.View;

using FinalProject.CharacterData;
using FinalProject.data;

public static class LevelUpHandler
{
    public static void LevelPointsMenu(Character character_na, DataStorage allData_na)
    {
        Console.Clear();
        Console.WriteLine("==================================================");
        Console.WriteLine($"   SPEND LEVEL POINTS: {character_na.CharName_na.ToUpper()}");
        Console.WriteLine("==================================================");
        Console.WriteLine($" Available Level Points: {character_na.LevelPoints_na}");
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine(" 1. Increase Core Stat (Costs 1 LP)");
        Console.WriteLine(" 2. Increase Skill (+5% per 1 LP)");
        Console.WriteLine(" 3. Acquire a Trait (Varied Cost)");
        Console.WriteLine(" 4. Return to Main Menu");
        Console.WriteLine("==================================================");

        int userChoice_na = GrabInput.IntInRange("Select an option (1-4): ", 1, 4);

        switch (userChoice_na)
        {
            case 1:
                IncreaseStat(character_na);
                break;
            case 2:
                IncreaseSkill(character_na);
                break;
            case 3:
                AddTrait(character_na, allData_na);
                break;
            case 4:
                break;
        }
    }

    public static void IncreaseStat(Character character_na)
    {
        Console.Clear();
        if (character_na.LevelPoints_na < 1)
        {
            Console.WriteLine("\n Sorry you don't have enough level points.");
        }
        
        Console.WriteLine("==================================================");
        Console.WriteLine("                INCREASE STAT                     ");
        Console.WriteLine("==================================================");
        ViewPrint.PrintCoreStats(character_na);
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("Options:");
        Console.WriteLine(" 1. HP");
        Console.WriteLine(" 2. ATK");
        Console.WriteLine(" 3. DEF");
        Console.WriteLine(" 4. SPATK");
        Console.WriteLine(" 5. SPDEF");
        Console.WriteLine(" 6. Speed");
        Console.WriteLine(" 7. Cancel");
        Console.WriteLine("--------------------------------------------------");

        int choice_na = GrabInput.IntInRange("Select a stat to increase by +1 (1-7): ", 1, 7);
        string selectedStat_na = choice_na switch
        {
            1 => "HP",
            2 => "ATK",
            3 => "DEF",
            4 => "SPATK",
            5 => "SPDEF",
            6 => "SPD",
            _ => null
        };

        if (selectedStat_na != null)
        {
            int currentVal_na = character_na.Stats_na.GetValue(selectedStat_na);
            if (selectedStat_na == "SPD")
            {
                character_na.Stats_na.SetValue(selectedStat_na, currentVal_na + 2);
            }
            else if (selectedStat_na == "HP")
            {
                character_na.Stats_na.SetValue(selectedStat_na, currentVal_na + 5);
            }
            else
            {
                character_na.Stats_na.SetValue(selectedStat_na, currentVal_na + 1);
            }
            character_na.SpendLevelPoint(1);
            Console.WriteLine($"\nSuccessfully increased {selectedStat_na} to {character_na.Stats_na.GetValue(selectedStat_na)}!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
    public static void IncreaseSkill(Character character_na)
    {
        Console.Clear();
        if (character_na.LevelPoints_na < 1)
        {
            Console.WriteLine("\n Sorry you don't have enough level points.");
        }

        Console.WriteLine("==================================================");
        Console.WriteLine("                INCREASE SKILL                    ");
        Console.WriteLine("==================================================");
        ViewPrint.PrintSkillList(character_na);
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine(" 1. Athletics        7. Performance");
        Console.WriteLine(" 2. Craft            8. Persuasion");
        Console.WriteLine(" 3. Endurance        9. Special Knowledge");
        Console.WriteLine(" 4. Finesse         10. Stealth");
        Console.WriteLine(" 5. Medicine        11. Survival");
        Console.WriteLine(" 6. Perception      12. Cancel");
        Console.WriteLine("--------------------------------------------------");

        int choice_na = GrabInput.IntInRange("Select a skill to boost by +5% (1-12): ", 1, 12);

        string selectedSkill_na = choice_na switch
        {
            1 => "Athletics",
            2 => "Craft",
            3 => "Endurance",
            4 => "Finesse",
            5 => "Medicine",
            6 => "Perception",
            7 => "Performance",
            8 => "Persuasion",
            9 => "Special Knowledge",
            10 => "Stealth",
            11 => "Survival",
            _ => null
        };

        if (selectedSkill_na != null)
        {
            int currentSkillVal_na = character_na.Skills_na.GetValue(selectedSkill_na);
            if (currentSkillVal_na < 95)
            {
                character_na.Skills_na.SetValue(selectedSkill_na, currentSkillVal_na + 5);
                Console.WriteLine($"\nSuccessfully boosted {selectedSkill_na} by +5% (New Total: {currentSkillVal_na + 5}%)!");
                character_na.SpendLevelPoint(1);
            }
            else
            {
                Console.WriteLine($"Cannot boost {selectedSkill_na} higher than 95%.");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
    public static void AddTrait(Character character_na, DataStorage allData_na)
    {
        Console.Clear();
        Console.WriteLine("==================================================");
        Console.WriteLine("                 ACQUIRE TRAIT                    ");
        Console.WriteLine("==================================================");
        Console.WriteLine($" Available Level Points: {character_na.LevelPoints_na}");
        Console.WriteLine("--------------------------------------------------");

        Trait newTrait_na = UserAssignmentHandler.GetAvailableTraits(allData_na, character_na);

        if (newTrait_na == null)
        {
            return;
        }

        if (character_na.LevelPoints_na < newTrait_na.Cost_na)
        {
            Console.WriteLine($"\nNot enough points! '{newTrait_na.Name_na}' requires {newTrait_na.Cost_na} LP, but you only have {character_na.LevelPoints_na}.");
            Console.WriteLine("Press any key to return...");
            Console.ReadKey();
            return;
        }

        character_na.AddTrait(newTrait_na);
        Console.WriteLine($"\nSuccessfully acquired the trait '{newTrait_na.Name_na}'!");
        character_na.SpendLevelPoint(newTrait_na.Cost_na);

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}
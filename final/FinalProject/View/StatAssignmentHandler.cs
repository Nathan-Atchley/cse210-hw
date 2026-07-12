namespace FinalProject.View;
using FinalProject.View;
using FinalProject.API;
using FinalProject.CharacterData;
using System;

public static class StatAssignmentHandler
{
    public static List<int> GetModifierArray()
    {
        Console.WriteLine("Choose one of the following arrays:");
        Console.WriteLine(" 1. General (+1, +1, 0, 0)");
        Console.WriteLine(" 2. Special (+2, 0, 0, 0)");
        Console.WriteLine(" 3. Expert (+3, 0, 0, -1)");
        Console.WriteLine(" 4. Weakspot (+1, +1, +1, -1)");
        Console.WriteLine(" 5. Lopsided (+2, +1, 0, -1)");
        List<int> modifierArray_na = null;
        bool choiceFlag_na = true;
        while (choiceFlag_na)
        {
            int userChoice_na = GrabInput.Int("Please enter the number of your desired stat array: ");
            switch (userChoice_na)
            {
                case 1:
                    modifierArray_na = StatArrays.GetArray(StatArrayType_na.General);
                    choiceFlag_na = false;
                    break;
                case 2:
                    modifierArray_na = StatArrays.GetArray(StatArrayType_na.Special);
                    choiceFlag_na = false;
                    break;
                case 3:
                    modifierArray_na = StatArrays.GetArray(StatArrayType_na.Expert);
                    choiceFlag_na = false;
                    break;
                case 4:
                    modifierArray_na = StatArrays.GetArray(StatArrayType_na.Weakspot);
                    choiceFlag_na = false;
                    break;
                case 5:
                    modifierArray_na = StatArrays.GetArray(StatArrayType_na.Lopsided);
                    choiceFlag_na = false;
                    break;
                default:
                    Console.WriteLine("Invalid entry please enter an integer 1-5");
                    break;

            }
        }

        return modifierArray_na;
    }
    public static Dictionary<string, int> AssignModifiersToStats(List<int> availableModifiers_na)
    {
        Dictionary<string, int> assignedBonus_na = new Dictionary<string, int>();
        List<string> remainingStats_na = new List<string> { "ATK", "DEF", "SPATK", "SPDEF" };
        List<int> pool_na = [.. availableModifiers_na];

        Console.WriteLine("Assign your array modifiers to your core stats.");

        foreach (int modifier_na in pool_na)
        {
            Console.WriteLine($"\nRemaining stats to assign: {string.Join(", ", remainingStats_na)}");
            Console.WriteLine($"Assign modifier value: {modifier_na}");

            string chosenStat_na = "";
            bool validChoice_na = false;

            while (!validChoice_na)
            {
                chosenStat_na = GrabInput.String("Enter stat name: ").Trim().ToUpper();
                if (remainingStats_na.Contains(chosenStat_na))
                {
                    validChoice_na = true;
                }
                else
                {
                    Console.WriteLine("Invalid stat or stat already assigned. Please pick from the remaining list.");
                }
            }
            assignedBonus_na[chosenStat_na] = modifier_na;
            remainingStats_na.Remove(chosenStat_na);
        }
        return assignedBonus_na;
    }
}
namespace FinalProject.View;
using FinalProject.API;
using FinalProject.CharacterData;
using FinalProject.data;
using System;
public static class ViewPrint
{
    public static async Task<Character> MakeCharacter(DataStorage allData_na)
    {
        string name_na = GrabInput.String("Enter Character name: ");
        PokemonData pkmnData_na = null;
        while(pkmnData_na == null)
        {
            string pkmnName_na = GrabInput.String("Enter your chosen Pokemon: ");
            pkmnData_na = await PullPokemonData(pkmnName_na);
        }
        PokemonSpecies species_na = new PokemonSpecies(pkmnData_na);

        Dictionary<string, int> statArray_na = StatAssignmentHandler.AssignModifiersToStats(StatAssignmentHandler.GetModifierArray());
        Trait chosenTrait_na = UserAssignmentHandler.GetTrait(allData_na);
        Background chosenBackground_na = UserAssignmentHandler.GetBackground(allData_na);
        Ability activeAbility_na = UserAssignmentHandler.GetAbility(species_na);

        Character playerCharacter_na = new Character(name_na, species_na, statArray_na, chosenBackground_na, activeAbility_na, chosenTrait_na);
        return playerCharacter_na;
    }

    public static void PrintCharacter(Character player_na)
    {
        Console.WriteLine($"Name: {player_na.CharName_na}");
        Console.WriteLine($"{player_na.Species_na} Lv{player_na.Level_na}");
        Console.WriteLine($"Moves: ");
        foreach (Move move_na in player_na.EquippedMoves_na)
        {
            Console.WriteLine($"{move_na.Name_na}");
        }
    }
    static async Task<PokemonData> PullPokemonData(string pkmnSpecies_na)
    {
        try
        {
            using (IPokeApi apiService = new PokeApi())
            {
                PokemonData pkmn_na = await apiService.GetPokemonDataAsync(pkmnSpecies_na);
                return pkmn_na;
            }    
        }
        catch (HttpRequestException)
        {
            Console.WriteLine($"Error: Could not find Pokemon '{pkmnSpecies_na}'.");
            return null;
        }
        catch (Exception error_na)
        {
            Console.WriteLine($"An unexpected error occurred: {error_na.Message}");
            return null;
        }
    }
}
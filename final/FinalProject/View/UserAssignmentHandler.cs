namespace FinalProject.View;

using FinalProject.View;
using FinalProject.API;
using FinalProject.CharacterData;
using System;
using FinalProject.data;

public static class UserAssignmentHandler
{
    public static Ability GetAbility(PokemonSpecies pokemonSpecies_na)
    {
        Console.WriteLine("Please choose your pokemon's ability: ");
        int i = 0;
        foreach (Ability ability_na in pokemonSpecies_na.AvailableAbilities)
        {
            i++;
            Console.WriteLine($" {i}. {ability_na.Name_na}\n      Description: {ability_na.Description_na}");
        }
        int abilityChoice_na = GrabInput.Int($"Enter your choice (1-{i}): ");
        while (abilityChoice_na < 1 || abilityChoice_na > i)
        {
            abilityChoice_na = GrabInput.Int($"Invalid selection. Please enter your choice (1-{i}): ");
        }
        return pokemonSpecies_na.AvailableAbilities[abilityChoice_na - 1];
    }
    public static Background GetBackground(DataStorage allData_na)
    {
        Console.WriteLine("Please choose a Background from the list:");
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
    public static Trait GetTrait(DataStorage allData_na)
    {
        Console.WriteLine("Please choose a Trait from the list:");
        List<Trait> traits_na = allData_na.GetAllBeginnerTraits();

        int i = 0;
        foreach (Trait trait_na in traits_na)
        {
            i++;
            Console.WriteLine($" {i}. {trait_na.Name_na}\n      Description: {trait_na.Description_na}");
        }

        int traitChoice = GrabInput.Int($"Enter the number of your Background choice (1-{i})");
        while (traitChoice < 1 || traitChoice > i)
        {
            traitChoice = GrabInput.Int($"Invalid selection. Please enter your choice (1-{i}): ");
        }

        return traits_na[traitChoice - 1];
    }
}
namespace FinalProject.data;

using FinalProject.API;
using FinalProject.CharacterData;
using System.Text.Json;

public static class CharacterSaveManager
{
    private const string SaveDirectory = "data/saves";

    private static void EnsureSaveDirectoryExists()
    {
        if (!Directory.Exists(SaveDirectory))
        {
            Directory.CreateDirectory(SaveDirectory);
        }
    }

    /// <summary>
    /// Converts a Character object into a CharacterSaveData DTO and serializes it to a JSON file.
    /// </summary>
    public static void SaveCharacter(Character character_na)
    {
        if (character_na == null)
            throw new ArgumentNullException(nameof(character_na));

        EnsureSaveDirectoryExists();

        // Map live Character data to CharacterSaveData DTO
        var saveData_na = new CharacterSaveData
        {
            CharName_na = character_na.CharName_na,
            SpeciesName_na = character_na.Species_na?.SpeciesName_na,
            Level_na = character_na.Level_na,
            Experience_na = character_na.Experience_na,
            LevelPoints_na = character_na.LevelPoints_na,
            Destiny_na = character_na.ChosenDestiny_na?.Name_na,
            ChosenPatron_na = character_na.ChosenDestiny_na?.PatronChoice_na,
            Poke_na = character_na.EquipmentLog_na?.Poke_na ?? 0,
            BackgroundName_na = character_na.ChosenBackground_na?.Name_na,
            AbilityName_na = character_na.ActiveAbility_na?.Name_na,
            Stats_na = character_na.StatArray_na != null ? new Dictionary<string, int>(character_na.StatArray_na) : new Dictionary<string, int>(),
            Skills_na = character_na.Skills_na != null ? character_na.Skills_na.GetAllValues() : new Dictionary<string, int>(),
            SpecialistFields_na = character_na.Skills_na?.SpecialistKnowledge_na != null ? new List<string>(character_na.Skills_na.SpecialistKnowledge_na) : new List<string>(),
            Proficiencies_na = character_na.Proficiencies_na ?? new List<string>(),
            Traits_na = character_na.SelectedTraits_na?.Select(t => t.Name_na).ToList() ?? new List<string>(),
            EquippedMoveNames_na = character_na.EquippedMoves_na?.Select(m => m.Name_na).ToList() ?? new List<string>()
        };

        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        string fileName_na = $"{character_na.CharName_na.Trim().Replace(" ", "_")}.json";
        string filePath_na = Path.Combine(SaveDirectory, fileName_na);

        string jsonString_na = JsonSerializer.Serialize(saveData_na, options);
        File.WriteAllText(filePath_na, jsonString_na);

        Console.WriteLine($"Character successfully saved to: {filePath_na}");
    }

    public static async Task<Character> LoadCharacterAsync(string filePath, DataStorage allData, IPokeApi pokeApi)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Save file does not exist.");
            return null;
        }

        string jsonString_na = await File.ReadAllTextAsync(filePath);
        CharacterSaveData saveData_na = JsonSerializer.Deserialize<CharacterSaveData>(jsonString_na);

        if (saveData_na == null)
        {
            Console.WriteLine("Failed to parse save data.");
            return null;
        }

        // 1. Fetch species data via API/DataStorage
        PokemonSpecies species_na = await pokeApi.GetPokemonDataAsync(saveData_na.SpeciesName_na, allData);
        if (species_na == null)
        {
            Console.WriteLine($"Error: Could not retrieve Pokémon species '{saveData_na.SpeciesName_na}'.");
            return null;
        }

        // 2. Fetch background data
        Background background_na = allData.GetBackground(saveData_na.BackgroundName_na);

        // 3. Find matching active ability
        Ability ability_na = species_na.AvailableAbilities_na
            .FirstOrDefault(a => a.Name_na.Equals(saveData_na.AbilityName_na, StringComparison.OrdinalIgnoreCase))
            ?? species_na.AvailableAbilities_na.FirstOrDefault();

        // 4. Reconstruct Trait list from loaded trait names
        List<Trait> traitsList_na = new List<Trait>();
        if (saveData_na.Traits_na != null)
        {
            foreach (string traitName_na in saveData_na.Traits_na)
            {
                Trait traitObj_na = allData.GetTrait(traitName_na);
                if (traitObj_na != null)
                {
                    traitsList_na.Add(traitObj_na);
                }
            }
        }

        // 5. Build SkillSheet
        SkillSheet skillSheet_na = new SkillSheet();
        if (saveData_na.Skills_na != null)
        {
            foreach (var kvp in saveData_na.Skills_na)
            {
                skillSheet_na.SetValue(kvp.Key, kvp.Value);
            }
        }
        if (saveData_na.SpecialistFields_na != null)
        {
            foreach (string field in saveData_na.SpecialistFields_na)
            {
                skillSheet_na.AddSpecialistKnowledge(field);
            }
        }

        // 6. Instantiate Character object
        Character loadedCharacter_na = new Character(saveData_na.CharName_na,species_na,saveData_na.Level_na,saveData_na.Experience_na,saveData_na.LevelPoints_na,saveData_na.Stats_na,background_na,ability_na,skillSheet_na,traitsList_na,saveData_na.Poke_na
        );

        // 7. Re-equip moves
        loadedCharacter_na.EquippedMoves_na.Clear();
        if (saveData_na.EquippedMoveNames_na != null)
        {
            foreach (string moveName_na in saveData_na.EquippedMoveNames_na)
            {
                Move moveObj_na = species_na.Moves_na.FirstOrDefault(m => m.Name_na.Equals(moveName_na, StringComparison.OrdinalIgnoreCase));
                if (moveObj_na != null)
                {
                    loadedCharacter_na.EquippedMoves_na.Add(moveObj_na);
                }
            }
        }

        // 8. Restore Proficiencies
        if (saveData_na.Proficiencies_na != null)
        {
            foreach (string proficiency_na in saveData_na.Proficiencies_na)
            {
                loadedCharacter_na.AddProficiency(proficiency_na);
            }
        }

        // 9. Restore Destiny
        if (!string.IsNullOrEmpty(saveData_na.Destiny_na))
        {
            Destiny destiny_na = allData.GetDestiny(saveData_na.Destiny_na);
            if (destiny_na != null)
            {
                if (!string.IsNullOrEmpty(saveData_na.ChosenPatron_na))
                {
                    destiny_na.SetDestinyPatron(saveData_na.ChosenPatron_na);
                }
                
                loadedCharacter_na.AddDestiny(destiny_na);
            }
        }

        return loadedCharacter_na;
    }

    /// <summary>
    /// Helper method to list all available save files in the saves directory.
    /// </summary>
    public static List<string> GetSaveFiles()
    {
        EnsureSaveDirectoryExists();
        return Directory.GetFiles(SaveDirectory, "*.json").ToList();
    }
}
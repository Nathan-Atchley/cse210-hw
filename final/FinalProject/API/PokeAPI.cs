namespace FinalProject.API;
using FinalProject.data;
using PokeApiNet;
//Mostly written by Gemini AI, but with some minor modifications
public class PokeApi : IPokeApi
{
    private readonly PokeApiClient _client;
    private bool _disposed;

    public PokeApi()
    {
        _client = new PokeApiClient();
    }

    public async Task<CharacterData.PokemonSpecies> GetPokemonDataAsync(string nameOrId, DataStorage allData_na)
    {
        CharacterData.PokemonSpecies pokemon_na = allData_na.getPokemon(nameOrId);
        if (pokemon_na != null)
        {
            return pokemon_na;
        }
        // 1. Fetch raw Pokemon object from PokeApiNet
        Pokemon pokemon = await _client.GetResourceAsync<Pokemon>(nameOrId.ToLowerInvariant());

        if (pokemon == null)
            return null;

        // 2. Map raw PokeApiNet data into our clean PokemonData model
        var data = new PokemonData
        {
            Id_na = pokemon.Id,
            Name_na = pokemon.Name
        };

        // Extract Types
        foreach (var t in pokemon.Types)
        {
            data.Types_na.Add(t.Type.Name);
        }

        // Extract Base Stats (hp, attack, defense, special-attack, special-defense, speed)
        foreach (var s in pokemon.Stats)
        {
            data.BaseStats_na[s.Stat.Name] = s.BaseStat;
        }

        // Extract Abilities
        foreach (var a in pokemon.Abilities)
        {
            string abiltyName = a.Ability.Name;
            string description = "No description available.";

            try
            {
                PokeApiNet.Ability fullAbility = await _client.GetResourceAsync<PokeApiNet.Ability>(abiltyName);
                if (fullAbility != null)
                {
                    var englishEntry = fullAbility.EffectEntries.FirstOrDefault(entry => entry.Language.Name == "en");
                    if (englishEntry != null)
                    {
                        description = englishEntry.Effect;
                    }
                    else if (fullAbility.FlavorTextEntries.Any())
                    {
                        var flavorEntry = fullAbility.FlavorTextEntries.FirstOrDefault(entry => entry.Language.Name == "en");
                        if (flavorEntry != null)
                        {
                            description = flavorEntry.FlavorText;
                        }
                    }
                }
            }
            catch (Exception){}

            data.Abilities_na[abiltyName] = description;
        }

        var excludedVersionGroups_na = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "legends-arceus",
            "legends-za"
        };

        foreach (var move_na in pokemon.Moves)
        {
            string moveName_na = move_na.Move.Name;

            var validGroupDetails = move_na.VersionGroupDetails
                    .Where(detail_na => !excludedVersionGroups_na.Contains(detail_na.VersionGroup.Name))
                    .ToList();
            if (!validGroupDetails.Any())
                continue;

            var latestDetail_na = validGroupDetails.Last();
            int levelLearned_na = Math.Min((latestDetail_na.LevelLearnedAt / 5) + 1, 20);
            string learnMethod_na = latestDetail_na.MoveLearnMethod.Name;
            
            MoveData moveData_na = await GetMoveDataAsync(moveName_na, learnMethod_na,levelLearned_na);
            CharacterData.Move moveObject_na = new CharacterData.Move(moveData_na, allData_na);
            data.Moves_na.Add(moveObject_na);
        }

        pokemon_na = new CharacterData.PokemonSpecies(data);
        allData_na.loadPokemon(pokemon_na);
        return pokemon_na;
    }

    public async Task<MoveData> GetMoveDataAsync(string moveName, string learnMethod_na, int levelLearned_na = 0)
    {
        PokeApiNet.Move move = await _client.GetResourceAsync<PokeApiNet.Move>(moveName.ToLowerInvariant());

        if (move == null)
            return null;

        return new MoveData
        {
            Name_na = move.Name,
            Type_na = move.Type.Name,
            DamageClass_na = move.DamageClass.Name,
            Power_na = (int)Math.Ceiling((move.Power ?? 0) / 10.0),
            Accuracy_na = move.Accuracy ?? 0,
            PP_na = move.Pp ?? 0,
            LearnMethod_na = learnMethod_na,
            Prerequisites_na = levelLearned_na,
            Description_na = move.EffectEntries.FirstOrDefault(e => e.Language.Name == "en")?.Effect ?? ""
        };
    }

    // Standard IDisposable cleanup for network sockets
    public void Dispose()
    {
        if (!_disposed)
        {
            _client?.Dispose();
            _disposed = true;
        }
        GC.SuppressFinalize(this);
    }
}
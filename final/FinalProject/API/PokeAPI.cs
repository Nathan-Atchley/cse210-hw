namespace FinalProject.API;
using FinalProject.View;
using FinalProject.API;
using FinalProject.CharacterData;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PokeApiNet;

public class PokeApi : IPokeApi
{
    private readonly PokeApiClient _client;
    private bool _disposed;

    public PokeApi()
    {
        _client = new PokeApiClient();
    }

    public async Task<PokemonData> GetPokemonDataAsync(string nameOrId)
    {
        // 1. Fetch raw Pokemon object from PokeApiNet
        Pokemon pokemon = await _client.GetResourceAsync<Pokemon>(nameOrId.ToLowerInvariant());

        if (pokemon == null)
            return null;

        // 2. Map raw PokeApiNet data into our clean PokemonData model
        var data = new PokemonData
        {
            Id = pokemon.Id,
            Name = pokemon.Name
        };

        // Extract Types
        foreach (var t in pokemon.Types)
        {
            data.Types.Add(t.Type.Name);
        }

        // Extract Base Stats (hp, attack, defense, special-attack, special-defense, speed)
        foreach (var s in pokemon.Stats)
        {
            data.BaseStats[s.Stat.Name] = s.BaseStat;
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

            data.Abilities[abiltyName] = description;
        }

        return data;
    }

    public async Task<MoveData> GetMoveDataAsync(string moveName)
    {
        PokeApiNet.Move move = await _client.GetResourceAsync<PokeApiNet.Move>(moveName.ToLowerInvariant());

        if (move == null)
            return null;

        return new MoveData
        {
            Name = move.Name,
            Type = move.Type.Name,
            DamageClass = move.DamageClass.Name,
            Power = move.Power,
            Accuracy = move.Accuracy,
            PP = move.Pp
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
namespace FinalProject.API;
using FinalProject.View;
using FinalProject.API;
using FinalProject.CharacterData;
using System;
using System.Threading.Tasks;

public interface IPokeApi : IDisposable
{

    Task<PokemonData> GetPokemonDataAsync(string nameOrId);

    Task<MoveData> GetMoveDataAsync(string moveName);
}
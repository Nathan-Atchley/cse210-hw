namespace FinalProject.API;
using System;
using System.Threading.Tasks;
using FinalProject.data;

public interface IPokeApi : IDisposable
{

    Task<CharacterData.PokemonSpecies> GetPokemonDataAsync(string nameOrId, DataStorage allData_na);

    Task<MoveData> GetMoveDataAsync(string moveName, string learnMethod_na, int levelLearned_na = 0);
}
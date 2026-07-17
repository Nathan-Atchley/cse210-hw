namespace FinalProject.data;
using FinalProject.View;
using FinalProject.CharacterData;

public class DataStorage
{
    private Dictionary<string, PokemonSpecies> _pokemon_na { get ; set ;}
    private Dictionary<string, Trait> _traits_na { get ; set ;}
    private Dictionary<string, string> _moveRanges_na { get ; set ;}
    private Dictionary<string, Background> _backgrounds_na { get ; set ;}
    private Dictionary<string, Destiny> _destinies_na { get ; set ;}
    public DataStorage()
    {
        _pokemon_na = new Dictionary<string, PokemonSpecies>();
        _traits_na = new Dictionary<string, Trait>();
        _moveRanges_na = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        _backgrounds_na = new Dictionary<string, Background>(StringComparer.OrdinalIgnoreCase);
        _destinies_na = new Dictionary<string, Destiny>(StringComparer.OrdinalIgnoreCase);
        
        loadTraits();
        loadBackgrounds();
        LoadMoveRanges();
        loadDestinies();
    }

    public void loadPokemon(PokemonSpecies pokemon_na)
    {
        _pokemon_na.Add(pokemon_na.SpeciesName_na, pokemon_na);
    }
    public PokemonSpecies getPokemon(string pokemonName_na)
    {
        if (_pokemon_na.ContainsKey(pokemonName_na))
        {
            return _pokemon_na[pokemonName_na];
        }
        else
        {
            return null;
        }
    }
    public void loadTraits()
    {
        var allTraits = JsonReader.LoadAllTraits();
        _traits_na = allTraits.ToDictionary(trait_na => trait_na.Name_na, trait_na => trait_na, StringComparer.OrdinalIgnoreCase);
    }

    public Trait GetTrait(string name_na)
    {
        return _traits_na[name_na] ;
    }
    public List<Trait> GetAllBeginnerTraits()
    {
        return _traits_na.Values.Where(trait_na => trait_na.Prerequisites_na == 1).ToList();
    }
    public List<Trait> GetAllAvailableTraits(Character character_na)
    {
        return _traits_na.Values.Where(trait_na => trait_na.Prerequisites_na <= character_na.Level_na).ToList();
    }

    public void loadBackgrounds()
    {
        var allBackgrounds_na = JsonReader.LoadAllBackgrounds();

        foreach (var background_na in allBackgrounds_na)
        {
            Trait pulledTrait_na = GetTrait(background_na.GrantedTrait_na);
            Background newBackground_na = new Background(background_na.Name_na, background_na.Description_na, pulledTrait_na, background_na.Poke_na, background_na.Items_na);
            _backgrounds_na.Add(background_na.Name_na, newBackground_na);
        }
    }
    public Background GetBackground(string name_na)
    {
        return _backgrounds_na[name_na];
    }
    
    public List<Background> GetAllBackgrounds()
    {
        return _backgrounds_na.Values.ToList();
    }

    public void LoadMoveRanges()
    {
        var moveRangeData_na = JsonReader.LoadMoveRanges();
        _moveRanges_na = moveRangeData_na
            .ToDictionary(
                moveRange_na => moveRange_na.Name_na.Replace(" ", "-").ToLowerInvariant(),
                moveRange_na => moveRange_na.Range_na ?? "1 Enemy", 
                StringComparer.OrdinalIgnoreCase);
    }
    public string GetRangeForMove(string moveName)
    {
        return _moveRanges_na[moveName] ?? "1 Enemy";
    }

    public void loadDestinies()
    {
        var allDestinies_na = JsonReader.LoadAllDestinies();
        _destinies_na = allDestinies_na.ToDictionary(
            dest_na => dest_na.Name_na,
            dest_na => dest_na,
            StringComparer.OrdinalIgnoreCase
        );
    }

    public Destiny GetDestiny(string name_na)
    {
        return _destinies_na[name_na];
    }

    public List<Destiny> GetAllDestinies()
    {
        return _destinies_na.Values.ToList();
    }
}
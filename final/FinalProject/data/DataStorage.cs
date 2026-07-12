namespace FinalProject.data;
using FinalProject.View;
using FinalProject.API;
using FinalProject.CharacterData;

public class DataStorage
{
    private Dictionary<string, Trait> _traits_na = new();
    private Dictionary<string, Background> _backgrounds_na = new Dictionary<string, Background>(StringComparer.OrdinalIgnoreCase);

    public void loadAllData()
    {
        loadTraits();
        loadBackgrounds();
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
}
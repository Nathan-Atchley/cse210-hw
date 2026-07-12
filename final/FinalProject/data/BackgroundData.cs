namespace FinalProject.data;
using FinalProject.View;
using FinalProject.API;
using FinalProject.CharacterData;
public class BackgroundData : CharacterFeature
{
    public string GrantedTrait_na { get ; }
    public int Poke_na { get ; }
    //change to list of Items later
    public List<string> Items_na { get ; }
    public BackgroundData(string name_na, string description_na, string grantedTrait_na, int poke_na, List<string> items_na, int prerequisites_na = 0) : base(name_na, description_na, prerequisites_na)
    {
        GrantedTrait_na = grantedTrait_na;
        Poke_na = poke_na;
        Items_na = items_na ?? new List<string>();
    }
    public override void ApplyToCharacter()
    {
        
    }
}
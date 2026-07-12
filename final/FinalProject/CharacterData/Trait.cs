namespace FinalProject.CharacterData;
using FinalProject.View;
using FinalProject.API;
using FinalProject.CharacterData;
public class Trait : CharacterFeature
{
    public int Cost_na { get ; }
    public Trait(string name_na, string description_na, int prerequisites_na, int cost_na) : base(name_na, description_na, prerequisites_na)
    {
        Cost_na = cost_na;
    }
    public override void ApplyToCharacter()
    {
        
    }
}
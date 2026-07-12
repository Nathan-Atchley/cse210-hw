namespace FinalProject.CharacterData;
using FinalProject.View;
using FinalProject.API;
using FinalProject.CharacterData;
public class Ability : CharacterFeature
{
    public Ability(string name_na, string description_na, int prerequisites_na = 0) : base(name_na, description_na, prerequisites_na){}
    public override void ApplyToCharacter()
    {
        
    }
}
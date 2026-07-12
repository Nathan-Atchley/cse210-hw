namespace FinalProject.CharacterData;
using FinalProject.View;
using FinalProject.API;
using FinalProject.CharacterData;
public class Destiny : CharacterFeature
{
    private CharacterFeature _Lv5Feature_na;
    private CharacterFeature _Lv15Feature_na;
    public Destiny(string name_na, string description_na, int prerequisites_na = 5) : base(name_na, description_na, prerequisites_na){}
    public override void ApplyToCharacter()
    {
        
    }
}
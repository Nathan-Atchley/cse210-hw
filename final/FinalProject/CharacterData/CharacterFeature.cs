namespace FinalProject.CharacterData;
using FinalProject.View;
using FinalProject.API;
using FinalProject.CharacterData;
public class CharacterFeature
{
    public string Name_na { get ; }
    public string Description_na { get ; }
    public int Prerequisites_na { get ; }

    
    public CharacterFeature(string name_na, string description_na, int prerequisites_na)
    {
        Name_na = name_na;
        Description_na = description_na;
        Prerequisites_na = prerequisites_na;
    }

    public virtual void ApplyToCharacter(){}
}
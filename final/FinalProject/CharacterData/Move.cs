namespace FinalProject.CharacterData;
using FinalProject.View;
using FinalProject.API;
using FinalProject.CharacterData;
public class Move : CharacterFeature
{
    private string _Type_na;
    private string _DamageClass_na;
    private int _PP_na;
    private int _Power_na;
    private int _Accuracy_na;
    private string _Range_na;
    public Move(string name_na, string description_na, int prerequisites_na, string type_na, string damageClass_na, int pp_na, int power_na, int accuracy_na, string range_na) 
        : base(name_na, description_na, prerequisites_na)
    {
        _Type_na = type_na;
        _DamageClass_na = damageClass_na;
        _PP_na = pp_na;
        _Power_na = power_na;
        _Accuracy_na = accuracy_na;
        _Range_na = range_na;
    }
    public override void ApplyToCharacter()
    {
        
    }
}
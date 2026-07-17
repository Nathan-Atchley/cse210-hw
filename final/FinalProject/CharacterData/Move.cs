namespace FinalProject.CharacterData;
using FinalProject.API;
using FinalProject.data;

public class Move : CharacterFeature
{
    public string Type_na { get ; }
    public string DamageClass_na { get ; }
    public int PP_na { get ; }
    public int Power_na { get ; }
    public int Accuracy_na { get ; }
    public string Range_na { get ; }
    public string LearnMethod_na { get; }
    public Move(MoveData moveData_na, DataStorage allData_na) 
        : base(moveData_na.Name_na, moveData_na.Description_na, moveData_na.Prerequisites_na)
    {
        Type_na = moveData_na.Type_na;
        DamageClass_na = moveData_na.DamageClass_na;
        PP_na = moveData_na.PP_na;
        Power_na = moveData_na.Power_na;
        Accuracy_na = moveData_na.Accuracy_na;
        Range_na = allData_na.GetRangeForMove(moveData_na.Name_na);
        LearnMethod_na = moveData_na.LearnMethod_na;
    }
    public override void ApplyToCharacter(Character player_na)
    {
        
    }
}
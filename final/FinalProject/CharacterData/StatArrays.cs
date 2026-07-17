namespace FinalProject.CharacterData;

public enum StatArrayType_na
{
    General,
    Special,
    Expert,
    Weakspot,
    Lopsided
}

public static class StatArrays
{
    public static List<int> GetArray(StatArrayType_na type_na)
    {
        return type_na switch
        {
            StatArrayType_na.General => new List<int> {1,1,0,0},
            StatArrayType_na.Special => new List<int> {2,0,0,0},
            StatArrayType_na.Expert => new List<int> {3,0,0,-1},
            StatArrayType_na.Weakspot => new List<int> {1,1,1,-1},
            StatArrayType_na.Lopsided => new List<int> {2,1,0,-1},
            _ => new List<int> {0,0,0,0}
        };
    }
}
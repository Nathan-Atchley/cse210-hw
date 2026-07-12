namespace FinalProject.CharacterData;
using FinalProject.View;
using FinalProject.API;
using FinalProject.CharacterData;
public class StatBlock : AttributeGroup
{
    public StatBlock(int HP_na, int ATK_na, int DEF_na, int SPATK_na, int SPDEF_na, int SPD_na, int STAB_na, int BASIC_na) : base()
    {
        SetValue("HP", HP_na);
        SetValue("ATK", ATK_na);
        SetValue("DEF", DEF_na);
        SetValue("SPATK", SPATK_na);
        SetValue("SPDEF", SPDEF_na);
        SetValue("SPD", SPD_na);
        SetValue("STAB", STAB_na);
        SetValue("BASIC", BASIC_na);
    }
}
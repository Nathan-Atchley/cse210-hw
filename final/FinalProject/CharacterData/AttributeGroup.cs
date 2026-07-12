namespace FinalProject.CharacterData;
using FinalProject.View;
using FinalProject.API;
using FinalProject.CharacterData;
public abstract class AttributeGroup
{
    private Dictionary<string, int> _Attributes;

    public AttributeGroup()
    {
        _Attributes = new Dictionary<string, int> ();
    }

    public int GetValue(string name_na)
    {
        int returnValue_na = _Attributes[name_na];
        return returnValue_na;
    }
    public void SetValue(string name_na, int value_na)
    {
        _Attributes[name_na] = value_na;
    }
}
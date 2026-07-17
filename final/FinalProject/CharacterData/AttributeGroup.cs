namespace FinalProject.CharacterData;
public abstract class AttributeGroup
{
    private Dictionary<string, int> _Attributes_na;

    public AttributeGroup()
    {
        _Attributes_na = new Dictionary<string, int> ();
    }

    public int GetValue(string name_na)
    {
        int returnValue_na = _Attributes_na[name_na];
        return returnValue_na;
    }
    public void SetValue(string name_na, int value_na)
    {
        _Attributes_na[name_na] = value_na;
    }
    public Dictionary<string, int> GetAllValues()
    {
        return new Dictionary<string, int>(_Attributes_na);
    }
}
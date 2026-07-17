namespace FinalProject.CharacterData;
public class Trait : CharacterFeature
{
    public int Cost_na { get ; }
    public Trait(string name_na, string description_na, int prerequisites_na, int cost_na) : base(name_na, description_na, prerequisites_na)
    {
        Cost_na = cost_na;
    }
    public override void ApplyToCharacter(Character player_na)
    {
        if (Name_na.Equals("Brick-Tough", StringComparison.OrdinalIgnoreCase) || 
            Name_na.Equals("Brick Tough", StringComparison.OrdinalIgnoreCase))
        {
            if (player_na.Stats_na != null)
            {
                int currentHp = player_na.Stats_na.GetValue("HP");
                player_na.Stats_na.SetValue("HP", currentHp + 10);
            }
        }
    }
}
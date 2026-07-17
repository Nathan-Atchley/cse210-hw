namespace FinalProject.CharacterData;
public class Background : CharacterFeature
{
    public Trait GrantedTrait_na { get ; }
    public int Poke_na { get ; }
    //change to list of Items later
    public List<string> Items_na { get ; }
    public Background(string name_na, string description_na, Trait grantedTrait_na, int poke_na, List<string> items_na, int prerequisites_na = 0) : base(name_na, description_na, prerequisites_na)
    {
        GrantedTrait_na = grantedTrait_na;
        Poke_na = poke_na;
        Items_na = items_na ?? new List<string>();
    }
    public override void ApplyToCharacter(Character player_na)
    {
        
    }
}
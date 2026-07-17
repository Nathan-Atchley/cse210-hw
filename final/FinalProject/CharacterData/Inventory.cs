namespace FinalProject.CharacterData;

public class Inventory
{
    public int Poke_na { get ; set ;}
    public Item HeldItem { get ; set ;}
    public List<Item> CarryingItems_na { get ; set ;}

    public Inventory()
    {
        Poke_na = 100;
        HeldItem = null;
        CarryingItems_na = new List<Item>();
    }
}
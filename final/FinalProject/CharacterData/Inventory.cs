namespace FinalProject.CharacterData;
using FinalProject.View;
using FinalProject.API;
using FinalProject.CharacterData;

public class Inventory
{
    private int _Poke_na;
    private Item _HeldItem;
    private List<Item> _CarryingItems_na;

    public Inventory()
    {
        _Poke_na = 100;
        _HeldItem = null;
        _CarryingItems_na = new List<Item>();
    }
}
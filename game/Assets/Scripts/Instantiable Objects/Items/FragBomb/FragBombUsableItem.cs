using UnityEngine;

public class FragBombUsableItem : UsableItem
{
    public int Uses;
    private int UsesLeft;
    public void Start()
    {
        UsesLeft = Uses;
    }
    public override bool CanCurrentlyUse(GameState gameState)
    {
        return !(UsesLeft <= 0);
    }

    public override bool IsCompletelyUsed()
    {
        return UsesLeft <= 0;
    }

    public override void Use()
    {
        UsesLeft--;
        Debug.Log("ITEM USED !!!");
    }
}

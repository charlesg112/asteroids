using UnityEngine;

public abstract class UsableItem : MonoBehaviour
{
    public ItemType ItemType;
    public abstract bool CanCurrentlyUse(GameState gameState);
    public abstract bool IsCompletelyUsed();
    public abstract void Use();
}

using UnityEngine;

public abstract class UsableItem : MonoBehaviour
{
    public abstract bool CanCurrentlyUse(GameState gameState);
    public abstract bool IsCompletelyUsed();
    public abstract void Use();
}

using UnityEngine;

public abstract class UIComponent : MonoBehaviour
{
    public void Start()
    {
        UIEventManager.Subscribe(this);
    }
    public void OnDestroy()
    {
        UIEventManager.Unsubscribe(this);
    }
    public abstract void Render(GameState gameState);
    public abstract bool IsUpdateRequired(GameState gameState);
    public void RenderIfRequired(GameState gameState)
    {
        if (IsUpdateRequired(gameState)) Render(gameState);
    }
    
}

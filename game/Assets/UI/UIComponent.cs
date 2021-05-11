using UnityEngine;

public abstract class UIComponent : MonoBehaviour
{
    public void Start()
    {
        UIEventManager.Subscribe(this);
    }
    public abstract void Render(GameStateDTO gameState);
    public abstract void RenderIfRequired(GameStateDTO gameState);
}

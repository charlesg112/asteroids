using UnityEngine;

public abstract class UIComponent<T> : MonoBehaviour
{
    public abstract void Render(T state);
    public abstract bool IsUpdateRequired(T state);
    public void RenderIfRequired(T state)
    {
        if (IsUpdateRequired(state)) Render(state);
    }
    
}

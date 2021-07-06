using UnityEngine;

public interface UIEventListener<T>
{
    public void onUIEvent(UIEventType eventType, UIComponent<T> source);
    public void onUIEvent(UIEventType eventType, KeyCode keyCode);
}

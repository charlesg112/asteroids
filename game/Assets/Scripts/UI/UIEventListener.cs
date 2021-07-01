using UnityEngine;

public interface UIEventListener
{
    public void onUIEvent(UIEventType eventType, UIComponent source);
    public void onUIEvent(UIEventType eventType, KeyCode keyCode);
}

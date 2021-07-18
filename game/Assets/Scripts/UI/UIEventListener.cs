using UnityEngine;

public interface UIEventListener
{
    public void onUIEvent(UIEventType eventType, Component source);
    public void onUIEvent(UIEventType eventType, KeyCode keyCode);
}

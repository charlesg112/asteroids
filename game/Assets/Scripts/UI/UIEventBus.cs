using System.Collections.Generic;
using UnityEngine;

public class UIEventBus<T> : MonoBehaviour
{
    private List<UIEventListener<T>> eventListeners = new List<UIEventListener<T>>();
    public void Subscribe(UIEventListener<T> listener)
    {
        eventListeners.Add(listener);
    }
    public void Publish(UIEventType type, UIComponent<T> source)
    {
        foreach (UIEventListener<T> listener in eventListeners)
        {
            listener.onUIEvent(type, source);
        }
    }
    public void Publish(UIEventType type, KeyCode keycode)
    {
        foreach (UIEventListener<T> listener in eventListeners)
        {
            listener.onUIEvent(type, keycode);
        }
    }
}

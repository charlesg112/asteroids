using System.Collections.Generic;
using UnityEngine;

public static class UIEventBus
{
    private static List<UIEventListener> eventListeners = new List<UIEventListener>();
    public static void Subscribe(UIEventListener listener)
    {
        eventListeners.Add(listener);
    }
    public static void Publish(UIEventType type, Component source)
    {
        foreach (UIEventListener listener in eventListeners)
        {
            listener.onUIEvent(type, source);
        }
    }
    public static void Publish(UIEventType type, KeyCode keycode)
    {
        foreach (UIEventListener listener in eventListeners)
        {
            listener.onUIEvent(type, keycode);
        }
    }
}

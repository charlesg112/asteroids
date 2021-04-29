using System.Collections.Generic;
using UnityEngine;

public static class EventBus
{
    private static List<EventListener> eventListeners = new List<EventListener>();
    public static void Subscribe(EventListener listener)
    {
        eventListeners.Add(listener);
    }
    public static void Publish(EventType type, GameObject source, int arg)
    {
        foreach (EventListener listener in eventListeners)
        {
            listener.onEvent(type, source, arg);
        }
    }
}

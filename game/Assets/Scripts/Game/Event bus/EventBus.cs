using System.Collections.Generic;
using UnityEngine;

public static class EventBus
{
    private static List<EventListener> eventListeners = new List<EventListener>();
    private static List<EventListener> uiEventManagers = new List<EventListener>();
    public static void Subscribe(EventListener listener)
    {
        eventListeners.Add(listener);
    }
    public static void SubsrcribeAsUIEventManager(EventListener listener)
    {
        uiEventManagers.Add(listener);
    }
    public static void Publish(EventType type, GameObject source, int arg)
    {
        foreach (EventListener listener in eventListeners)
        {
            listener.onEvent(type, source, arg);
        }
        foreach (EventListener listener in uiEventManagers)
        {
            listener.onEvent(type, source, arg);
        }
    }
}


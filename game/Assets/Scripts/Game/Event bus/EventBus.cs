using System.Collections.Generic;
using UnityEngine;

public class EventBus : MonoBehaviour
{
    private List<EventListener> eventListeners = new List<EventListener>();
    private List<EventListener> uiEventManagers = new List<EventListener>();
    public void Subscribe(EventListener listener)
    {
        eventListeners.Add(listener);
    }
    public void SubsrcribeAsUIEventManager(EventListener listener)
    {
        uiEventManagers.Add(listener);
    }
    public void Publish(EventType type, GameObject source, int arg)
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


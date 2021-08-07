using System.Collections.Generic;
using UnityEngine;

public abstract class SelectiveUIEventManager<T> : UIEventManager<T>
{
    protected abstract List<EventType> GetForceRefreshEvents();
    protected abstract List<EventType> GetIgnoreEvents();
    public override void onEvent(EventType eventType, GameObject source, int arg)
    {
        if (GetIgnoreEvents().Contains(eventType)) return;
        if (GetForceRefreshEvents().Contains(eventType))
        {
            RenderAllComponents();       
        }
        else
        {
            UpdateGameState();
        }
    }

    public override void FirstRender()
    {
        UpdateGameState();
    }
}

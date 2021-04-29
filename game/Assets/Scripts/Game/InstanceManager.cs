using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceManager : MonoBehaviour, EventListener
{
    public static int BULLETS_INSTANCIATED = 0;
    
    public void Start()
    {
        EventBus.Subscribe(this);    
    }

    void EventListener.onEvent(EventType eventType, GameObject source, int arg)
    {
        switch(eventType)
        {
            case EventType.BulletFired:
                HandleBulletFiredEvent(); break;
            case EventType.BulletDestroyed:
                HandleBulletDestroyedEvent(); break;
        }
    }


    private void HandleBulletFiredEvent()
    {
        BULLETS_INSTANCIATED += 1;
    }

    private void HandleBulletDestroyedEvent()
    {
        BULLETS_INSTANCIATED -= 1;
    }
}

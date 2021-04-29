using UnityEngine;

public interface EventListener
{
    public void onEvent(EventType eventType, GameObject source, int arg);
}

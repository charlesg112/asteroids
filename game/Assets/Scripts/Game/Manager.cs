using UnityEngine;

public abstract class  Manager : MonoBehaviour, EventListener
{
    public abstract void onEvent(EventType eventType, GameObject source, int arg);

    void Start()
    {
        EventBus.Subscribe(this);
    }
}

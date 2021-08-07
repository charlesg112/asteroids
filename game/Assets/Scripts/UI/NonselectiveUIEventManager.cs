using UnityEngine;

public abstract class NonselectiveUIEventManager<T> : UIEventManager<T>
{
    public override void onEvent(EventType eventType, GameObject source, int arg)
    {
        UpdateGameState();
    }

    public override void FirstRender()
    {
        UpdateGameState();
    }
}

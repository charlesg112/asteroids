using UnityEngine;

public class InstanceManager : MonoBehaviour, EventListener
{
    public static int BULLETS_INSTANCIATED = 0;
    public static int ASTEROIDS_INSTANCIATED;
    
    public void Start()
    {
        EventBus.Subscribe(this);
        UpdateAsteroidsInstanciated();
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
        UpdateAsteroidsInstanciated();
        SendNoAsteroidsLeftEventIfNoAsteroidsLeft();
    }
    
    private void UpdateAsteroidsInstanciated()
    {
        ASTEROIDS_INSTANCIATED = GameObject.FindGameObjectsWithTag(GameInfo.TAG_OF_ASTEROID_CLASS_0).Length +
            GameObject.FindGameObjectsWithTag(GameInfo.TAG_OF_ASTEROID_CLASS_1).Length;
        Debug.Log($"----------------------- ASTEROIDS LEFT : {ASTEROIDS_INSTANCIATED} ------------------------------");
    }
    private void SendNoAsteroidsLeftEventIfNoAsteroidsLeft()
    {
        if (ASTEROIDS_INSTANCIATED == 0)
        {
            GameManager.NotifyGameEnded();
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

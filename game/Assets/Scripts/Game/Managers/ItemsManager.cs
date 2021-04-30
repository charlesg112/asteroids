using UnityEngine;

public class ItemsManager : Manager
{
    public static int BULLETS_PICKED_UP = 0;
    public override void onEvent(EventType eventType, GameObject source, int arg)
    {
        switch(eventType)
        {
            case EventType.PickableBulletPickedUp:
                HandlePickableBulletPickedUp(); break;
        }
    }

    private void HandlePickableBulletPickedUp()
    {
        BULLETS_PICKED_UP++;
    }
}

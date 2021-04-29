using UnityEngine;

public class PickableBullet : PickableItem
{
    internal override void PlayerCollisionEvent(Collider2D collider)
    {
        EventBus.Publish(EventType.PickableBulletPickedUp, this.gameObject, 1);
        Destroy(this.gameObject);
    }
}

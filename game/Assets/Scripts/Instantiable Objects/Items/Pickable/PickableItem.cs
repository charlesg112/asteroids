using UnityEngine;

public class PickableItem : PickableObject
{
    public UsableItem ItemGivenOnPickUp;
    internal override void PlayerCollisionEvent(Collider2D collider)
    {
        Debug.Log("Collided with player !");
        EventBus.Publish(EventType.PickableItemPickedUp, this.gameObject, 1);
        Destroy(this.gameObject);
    }
}

using UnityEngine;

public class PickableItem : PickableObject
{
    public UsableItem ItemGivenOnPickUp;
    internal override void PlayerCollisionEvent(Collider2D collider)
    {
        InventorySupervisor.GetInstance().AddItem(GameObject.Instantiate(ItemGivenOnPickUp));
        EventBus.Publish(EventType.PickableItemPickedUp, this.gameObject, 1);
        Destroy(this.gameObject);
    }
}

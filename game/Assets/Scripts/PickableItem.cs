using UnityEngine;

public abstract class PickableItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.layer)
        {
         case GameInfo.LAYER_OF_PLAYER:
                PlayerCollisionEvent(collision); break;
        }
    }

    internal abstract void PlayerCollisionEvent(Collider2D collider);
}

using UnityEngine;

public abstract class BorderBound : MonoBehaviour
{
    protected abstract void BorderCollisionEvent(Collider2D collider);

    public void OnTriggerEnter2D(Collider2D collider)
    {
        switch (collider.gameObject.layer)
        {
            case GameInfo.LAYER_OF_WALLS:
                this.BorderCollisionEvent(collider); break;
        }
    }

}

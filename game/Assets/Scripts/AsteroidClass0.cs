using UnityEngine;

public class AsteroidClass0 : Asteroid
{

    protected override void AsteroidCollisionEvent(Collision2D collision)
    {
        Debug.Log("Collided with asteroid");
    }

    protected override void PlayerCollisionEvent(Collision2D collision)
    {
        Debug.Log("Collided with player");
    }

    protected override void ProjectileCollisionEvent(Collider2D collision)
    {
        DefaultProjectilleCollisionEventHandler(collision);
    }

}

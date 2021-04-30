using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Projectile
{
    protected override void AsteroidCollisionEvent(Collider2D collider)
    {
        Debug.Log("Projectile collided with Asteroid");
        Destroy(this.gameObject);
    }

    protected override void BorderCollisionEvent(Collider2D collider)
    {
        Destroy(this.gameObject);
    }

    protected override void PlayerCollisionEvent(Collider2D collider)
    {
        
    }

    protected override void ProjectileCollisionEvent(Collider2D collider)
    {
        Debug.Log("Collided with another projectile");
    }
}

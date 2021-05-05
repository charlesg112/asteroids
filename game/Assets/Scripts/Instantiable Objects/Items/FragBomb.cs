using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragBomb : Projectile
{
    new void Start()
    {
        projectileBody.AddForce(new Vector2(2, 2));
    }

    protected override void AsteroidCollisionEvent(Collider2D collider)
    {
        throw new System.NotImplementedException();
    }

    protected override void BorderCollisionEvent(Collider2D collider)
    {
        throw new System.NotImplementedException();
    }

    protected override void PlayerCollisionEvent(Collider2D collider)
    {
        throw new System.NotImplementedException();
    }

    protected override void ProjectileCollisionEvent(Collider2D collider)
    {
        throw new System.NotImplementedException();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBorderBounder : BorderBound
{
    protected override void BorderCollisionEvent()
    {
        Vector2 oldVelocity = body.velocity;
        body.velocity = new Vector2(oldVelocity.x, -oldVelocity.y);
        Debug.Log("Collided with edge of cam");
    }
}

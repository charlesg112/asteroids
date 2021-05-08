using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionUtils : MonoBehaviour
{
    public static void ManageBorderCollisionEvent(Collider2D collision, Rigidbody2D rigidBody)
    {
        if (collision.gameObject.name == "left" || collision.gameObject.name == "right")
        {
            rigidBody.velocity = new Vector2(-rigidBody.velocity.x, rigidBody.velocity.y);
        }
        else if (collision.gameObject.name == "top" || collision.gameObject.name == "bottom")
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, -rigidBody.velocity.y);
        }
    }
}

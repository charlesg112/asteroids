using UnityEngine;

public class AsteroidClassA : Asteroid
{
    public GameObject children;
    public int SpawnedChildren;

    public override void ExplosionEvent()
    {
        Debug.Log("Exploded");
    }

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
        float incomingAngle = collision.gameObject.transform.rotation.eulerAngles.z;
        for (int i = 0; i < SpawnedChildren; ++i)
        {
            float resultingAngle = incomingAngle + 90 + (360/SpawnedChildren) * i;
            GameObject child = GameObject.Instantiate(children, transform.position, Quaternion.Euler(new Vector3(0, 0, resultingAngle)));
        }
        DefaultProjectileCollisionEventHandler(collision);
    }
}

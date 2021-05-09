using UnityEngine;

public class AsteroidClass0 : Asteroid
{

    public ItemDropper ItemDropper;


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
        ItemDropper.Drop();
        DefaultProjectileCollisionEventHandler(collision);
    }

    public void Update()
    {
        GravityManager.ApplyForceOnRigidBody(this.rigidBody);
    }

    public override void ExplosionEvent()
    {
        ItemDropper.Drop();
        DefaultDestructionEventHandler();
    }
}

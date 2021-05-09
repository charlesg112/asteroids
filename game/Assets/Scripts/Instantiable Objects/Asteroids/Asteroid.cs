using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public abstract class Asteroid : BorderBound
{
    public float initialVelocity;
    public Rigidbody2D rigidBody;
    public GameObject OnDestroyParticleSystem;

    void Start()
    {
        Debug.Log($"New Asteroid : Velocity of {initialVelocity}, Angle of {transform.rotation.eulerAngles.z}");
        rigidBody.velocity = Geometry.ModulateVelocity(transform.rotation.eulerAngles.z, initialVelocity);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch(collision.gameObject.layer)
        {
            case GameInfo.LAYER_OF_PLAYER:
                this.PlayerCollisionEvent(collision); break;
            case GameInfo.LAYER_OF_ASTEROIDS:
                this.AsteroidCollisionEvent(collision); break;
        }
    }

    private new void OnTriggerEnter2D(Collider2D collider)
    {
        base.OnTriggerEnter2D(collider);
        switch(collider.gameObject.layer)
        {
            case GameInfo.LAYER_OF_PROJECTILES:
                this.ProjectileCollisionEvent(collider); break;
        }
    }

    protected override void BorderCollisionEvent(Collider2D collision)
    {
        CollisionUtils.ManageBorderCollisionEvent(collision, this.rigidBody);
    }

    public void OnDestroy()
    {
        EventBus.Publish(EventType.AsteroidDestroyed, this.gameObject, 1);
    }

    protected abstract void PlayerCollisionEvent(Collision2D collision);
    protected abstract void AsteroidCollisionEvent(Collision2D collision);
    protected abstract void ProjectileCollisionEvent(Collider2D collision);
    public abstract void ExplosionEvent();
    protected void DefaultProjectileCollisionEventHandler(Collider2D collision)
    {
        Projectile projectile = collision.GetComponent(typeof(Projectile)) as Projectile;
        projectile.NotifyCollidedWithAsteroid(null);
        DefaultDestructionEventHandler();
    }

    protected void DefaultDestructionEventHandler()
    {
        GameObject particleSystem = GameObject.Instantiate(OnDestroyParticleSystem, this.transform.position, Quaternion.identity);
        GameObject.Destroy(particleSystem, 1);
        Destroy(this.gameObject);
    }
}

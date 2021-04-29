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
        if (collision.gameObject.name == "left" || collision.gameObject.name == "right")
        {
            rigidBody.velocity = new Vector2(-rigidBody.velocity.x, rigidBody.velocity.y);
        }
        else if (collision.gameObject.name == "top" || collision.gameObject.name == "bottom")
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, -rigidBody.velocity.y);
        }
    }

    public void OnDestroy()
    {
        EventBus.Publish(EventType.AsteroidDestroyed, this.gameObject, 1);
    }

    protected abstract void PlayerCollisionEvent(Collision2D collision);
    protected abstract void AsteroidCollisionEvent(Collision2D collision);
    protected abstract void ProjectileCollisionEvent(Collider2D collision);
    protected void DefaultProjectilleCollisionEventHandler(Collider2D collision)
    {
        GameObject particleSystem = GameObject.Instantiate(OnDestroyParticleSystem, this.transform.position, Quaternion.identity);
        GameObject.Destroy(particleSystem, 1);
        Projectile projectile = collision.GetComponent(typeof(Projectile)) as Projectile;
        projectile.NotifyCollidedWithAsteroid(null);
        Destroy(this.gameObject);
    }
}

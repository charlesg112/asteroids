using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    public Rigidbody2D projectileBody;
    public float speed;

    protected void Start()
    {
        projectileBody.velocity = Geometry.ModulateVelocity(transform.rotation.eulerAngles.z, speed);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        switch (collider.gameObject.layer)
        {
            case GameInfo.LAYER_OF_ASTEROIDS:
                AsteroidCollisionEvent(collider); break;
            case GameInfo.LAYER_OF_PLAYER:
                PlayerCollisionEvent(collider); break;
            case GameInfo.LAYER_OF_WALLS:
                BorderCollisionEvent(collider); break;
            case GameInfo.LAYER_OF_PROJECTILES:
                ProjectileCollisionEvent(collider); break;
        }
    }

    private void OnDestroy()
    {
        EventBus.Publish(EventType.BulletDestroyed, this.gameObject, 1);
    }

    public void NotifyCollidedWithAsteroid(Collider2D collider)
    {
        AsteroidCollisionEvent(collider);
    }
    protected abstract void AsteroidCollisionEvent(Collider2D collider);
    protected abstract void PlayerCollisionEvent(Collider2D collider);
    protected abstract void BorderCollisionEvent(Collider2D collider);
    protected abstract void ProjectileCollisionEvent(Collider2D collider);
}

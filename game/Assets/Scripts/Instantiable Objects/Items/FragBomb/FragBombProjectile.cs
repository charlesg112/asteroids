using System.Collections;
using UnityEngine;

public class FragBombProjectile : ThrowableProjectile
{
    public float ExplosionRadius;
    public float Mass;
    new void Start()
    {
        Vector2 initialForce = Geometry.ModulateVelocity(this.gameObject.transform.rotation.eulerAngles.z, speed);
        Debug.Log($"Added initial force : {initialForce}");
        projectileBody.AddForce(initialForce);
        GravityManager.AddGravityPoint(new GravityPoint(this.gameObject, Mass));
        StartCoroutine(LifeTime());
    }

    private void OnDestroy()
    {
        GravityManager.RemoveGravityPoint(this.gameObject);
    }

    protected override void AsteroidCollisionEvent(Collider2D collider)
    {
        throw new System.NotImplementedException();
    }

    protected override void BorderCollisionEvent(Collider2D collider)
    {
        CollisionUtils.ManageBorderCollisionEvent(collider, this.projectileBody);
    }

    protected override void PlayerCollisionEvent(Collider2D collider)
    {
        throw new System.NotImplementedException();
    }

    protected override void ProjectileCollisionEvent(Collider2D collider)
    {
        throw new System.NotImplementedException();
    }

    protected override IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(2);
        ExplosionsManager.DamageAsteroidsInRadius(this.gameObject.transform.position, ExplosionRadius, null);
        Destroy(this.gameObject);
    }
}

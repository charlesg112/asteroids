using System.Collections;

public abstract class ThrowableProjectile : Projectile
{
    protected abstract IEnumerator LifeTime();
}
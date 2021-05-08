using System.Collections;

public abstract class ThrowableItem : Projectile
{
    protected abstract IEnumerator LifeTime();
}
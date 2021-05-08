using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Rigidbody2D player;
    public Object bullet;

    void Fire()
    {
        Object bulletInstance = Instantiate(bullet, player.position, GameInfo.GetAngleBetweenPlayerAndMouse());
        EventBus.Publish(EventType.BulletFired, this.gameObject, 1);
    }

    void Update()
    {
        bool fire = Input.GetButtonDown("Fire1");
        if (fire)
        {
            if (canFire())
            {
                Fire();
            }
        }
    }

    bool canFire()
    {
        return GameInfo.GetBulletsInstanciated() < GameInfo.GetMaximumBulletsInstantiated();
    }
}

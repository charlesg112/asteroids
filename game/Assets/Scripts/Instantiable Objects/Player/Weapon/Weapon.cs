using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Rigidbody2D player;
    public Object bullet;
    
    Quaternion GetBulletInitialRotation()
    {
        Vector2 playerCenter = player.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return Geometry.GetQuaternionAngleBetweenPoints(playerCenter, mousePosition);
    }

    void Fire()
    {
        Object bulletInstance = Instantiate(bullet, player.position, GetBulletInitialRotation());
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

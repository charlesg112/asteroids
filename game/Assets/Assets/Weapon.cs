using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Rigidbody2D player;
    public Object bullet;
    Vector2 GetBulletDirectionNormal()
    {
        Vector2 playerCenter = player.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 diff = mousePosition - playerCenter;
        return diff.normalized;
    }

    float GetBulletDirectionAngle()
    {

        Vector2 direction = GetBulletDirectionNormal();
        float angle = Mathf.Atan(direction.y / direction.x);
        angle = Mathf.Abs(angle) * Mathf.Rad2Deg;
        if (direction.x < 0 && direction.y > 0)
        {
            angle = 180 - angle;
        }
        if (direction.x < 0 && direction.y < 0)
        {
            angle += 180;
        }
        if (direction.x > 0 && direction.y < 0)
        {
            angle = 360 - angle;
        }
        return angle;
    }
    
    Quaternion GetBulletInitialRotation()
    {
        float angle = GetBulletDirectionAngle();
        return Quaternion.Euler(0, 0, angle);
    }

    void Fire()
    {
        Object bulletInstance = Instantiate(bullet, player.position, GetBulletInitialRotation());
    }

    void Update()
    {
        bool fire = Input.GetButtonDown("Fire1");
        if (fire)
        {
            Debug.Log($"Normal : {GetBulletDirectionNormal()}");
            Debug.Log($"Angle : {GetBulletDirectionAngle()}");
            Fire();
        }
    }
}

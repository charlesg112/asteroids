using UnityEngine;

public static class Geometry
{
    public static float GetEulerAngleBetweenPoints(Vector2 from, Vector2 to)
    {
        Vector2 direction = (to - from).normalized;
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

    public static Quaternion GetQuaternionAngleBetweenPoints(Vector2 from, Vector2 to)
    {
        float angle = GetEulerAngleBetweenPoints(from, to);
        return GetQuaternionFromEuleurAngle(angle);
    }

    public static Quaternion GetQuaternionFromEuleurAngle(float euleurAngle)
    {
        return Quaternion.Euler(0, 0, euleurAngle);
    }

    public static Vector2 ModulateVelocity(Vector2 direction, float velocity)
    {
        return direction.normalized * velocity;
    }

    public static Vector2 ModulateVelocity(float angle, float velocity)
    {
        Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
        return ModulateVelocity(direction, velocity);
    }
}

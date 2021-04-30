using System.Collections.Generic;
using UnityEngine;

public static class GravityManager
{
    private static List<GravityPoint> gravityPoints = new List<GravityPoint>();
    
    public static List<GravityPoint> GetGravityPoints()
    {
        return gravityPoints;
    }

    public static void AddGravityPoint(GravityPoint gravityPoint)
    {
        gravityPoints.Add(gravityPoint);
    }

    public static void RemoveGravityPoint(GameObject gameObject)
    {
        gravityPoints.RemoveAll((p) => p.GameObject == gameObject);
    }

    public static void ApplyForceOnRigidBody(Rigidbody2D rigidbody)
    {
        foreach (GravityPoint gravityPoint in gravityPoints)
        {
            Vector2 gravityPointPosition = gravityPoint.GameObject.transform.position;
            Vector2 direction = (gravityPointPosition - rigidbody.position).normalized;
            rigidbody.AddForce(direction * gravityPoint.Weight / rigidbody.mass);
        }
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionsManager : MonoBehaviour
{
    public static void DamageAsteroidsInRadius(Vector2 center, float radius, List<String> tags)
    {
        Debug.Log("Damage asteroids in radius called");
        GameObject[] class0 = GameObject.FindGameObjectsWithTag(GameInfo.TAG_OF_ASTEROID_CLASS_0);
        Debug.Log($"GameObjects found : {class0.Length}");
        foreach (GameObject asteroid in class0)
        {
            Debug.Log($"Distance : {Geometry.GetDistanceBetweeenPoints(center, asteroid.transform.position)}");
            if (Geometry.GetDistanceBetweeenPoints(center, asteroid.transform.position) < radius)
            {
                Debug.Log($"Destroying asteroid : {Geometry.GetDistanceBetweeenPoints(center, asteroid.transform.position)} < {radius}");
                Destroy(asteroid);
            }
        }
    }
}

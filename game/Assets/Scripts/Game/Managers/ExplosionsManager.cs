using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionsManager : MonoBehaviour
{
    public static void DamageAsteroidsInRadius(Vector2 center, float radius, List<String> tags)
    {
        GameObject[] class0 = GameObject.FindGameObjectsWithTag(GameInfo.TAG_OF_ASTEROID_CLASS_0);
        foreach (GameObject asteroidGameObject in class0)
        {
            if (Geometry.GetDistanceBetweeenPoints(center, asteroidGameObject.transform.position) < radius)
            {
                Asteroid asteroidComponent = (Asteroid) asteroidGameObject.GetComponent(typeof(Asteroid));
                asteroidComponent.ExplosionEvent();
            }
        }
    }
}

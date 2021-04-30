using UnityEngine;

public struct GravityPoint
{
    public GameObject GameObject { get; }
    public float Weight { get; }
    public GravityPoint(GameObject gameObject, float weight)
    {
        GameObject = gameObject;
        Weight = weight;
    }
}
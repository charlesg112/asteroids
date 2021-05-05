using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject FragBombInstance;
    public void InstantiateFragBomb(Vector2 Position, float rotation)
    {
        Instantiate(FragBombInstance, Position, Geometry.GetQuaternionFromEuleurAngle(rotation));
    }
}

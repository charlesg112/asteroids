using System.Collections.Generic;
using UnityEngine;

public static class GameInfo
{
    public const int LAYER_OF_WALLS = 6;
    public const int LAYER_OF_PROJECTILES = 7;
    public const int LAYER_OF_PLAYER = 8;
    public const int LAYER_OF_ASTEROIDS = 9;
    public static List<GravityPoint> gravityPoints;
    public static int GetMaximumBulletsInstantiated()
    {
        return ItemsManager.BULLETS_PICKED_UP + 1;
    }

    public static int GetBulletsInstanciated()
    {
        return InstanceManager.BULLETS_INSTANCIATED;
    }

    public static Vector2 GetPlayerPosition()
    {
        Vector3 playerPosition = GameObject.Find("Player").transform.position;
        return new Vector2(playerPosition.x, playerPosition.y);
    }
}

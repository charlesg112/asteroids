using System.Collections.Generic;
using UnityEngine;

public static class GameInfo
{
    // Layers
    public const int LAYER_OF_WALLS = 6;
    public const int LAYER_OF_PROJECTILES = 7;
    public const int LAYER_OF_PLAYER = 8;
    public const int LAYER_OF_ASTEROIDS = 9;
    public const int LAYER_OF_DROP = 10;
    public const int LAYER_OF_FRAGBOMB = 11;

    // Tags
    public const string TAG_OF_ASTEROID_CLASS_0 = "AsteroidClass0";
    public const string TAG_OF_ASTEROID_CLASS_1 = "AsteroidClass1";
    public const string TAG_OF_MENU_LEVEL_BUTTON = "MenuLevelButton";

    // Scene identifiers
    public const string SCENE_NAME_OF_DEFAULT_END_SCREEN = "scene_default_end_screen";
    public const string SCENE_NAME_OF_MENU_SCREEN = "scene_menu";

    // Ui elements names
    public const string GAMEOBJECT_NAME_OF_END_SCREEN_LEVEL_TITLE = "level_title";
    public const string GAMEOBJECT_NAME_OF_END_SCREEN_NEXT_LEVEL_BUTTON = "next_level_button";
    public const string GAMEOBJECT_NAME_OF_MENU_SCREEN_LEVEL_BUTTON_SCORE = "level_text_score";
    public const string GAMEOBJECT_NAME_OF_MENU_SCREEN_LEVEL_BUTTON_NAME = "level_text_name";

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

    public static Vector2 GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public static Quaternion GetAngleBetweenPlayerAndMouse()
    {
        return Geometry.GetQuaternionAngleBetweenPoints(GetPlayerPosition(), GetMousePosition());
    }
}

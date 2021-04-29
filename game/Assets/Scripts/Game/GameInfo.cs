public static class GameInfo
{
    public const int LAYER_OF_WALLS = 6;
    public const int LAYER_OF_PROJECTILES = 7;
    public const int LAYER_OF_PLAYER = 8;
    public const int LAYER_OF_ASTEROIDS = 9;
    public static int GetMaximumBulletsInstantiated()
    {
        return ItemsManager.BULLETS_PICKED_UP + 1;
    }

    public static int GetBulletsInstanciated()
    {
        return InstanceManager.BULLETS_INSTANCIATED;
    }
}

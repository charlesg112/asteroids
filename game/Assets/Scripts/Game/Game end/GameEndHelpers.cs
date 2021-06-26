public static class GameEndHelpers
{
    public static void TransitionToGameEndedScreen(LevelData levelData)
    {
        // TODO - Loading bar
        GameEndSceneLoader.LoadGameEndScreen(levelData);
    }
}

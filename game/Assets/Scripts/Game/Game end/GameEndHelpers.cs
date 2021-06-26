public static class GameEndHelpers
{
    public static void TransitionToGameEndedScreen(LevelData levelData)
    {
        // TODO - Loading bar
        PersistentStateManager.SaveLevelCompletionData(levelData);
        GameEndSceneLoader.LoadGameEndScreen(levelData);
    }
}

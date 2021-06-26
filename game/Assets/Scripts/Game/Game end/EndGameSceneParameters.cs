public class EndGameSceneParameters 
{
    public LevelData CurrentLevelData;
    public LevelData NextLevelData;
    public EndGameSceneParameters(LevelData currentLevelData, LevelData nextLevelData)
    {
        CurrentLevelData = currentLevelData;
        NextLevelData = nextLevelData;
    }
}


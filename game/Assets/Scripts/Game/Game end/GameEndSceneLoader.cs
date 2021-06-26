using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndSceneLoader
{
    public static EndGameSceneParameters EndGameSceneParameters;
    public static AsyncOperation LoadGameEndScreen(LevelData currenLevelData)
    {
        EndGameSceneParameters = GetEndGameSceneParameters(currenLevelData);
        return SceneManager.LoadSceneAsync(GameInfo.SCENE_NAME_OF_DEFAULT_END_SCREEN);
    }
    private static EndGameSceneParameters GetEndGameSceneParameters(LevelData currentLevelData)
    {
        LevelData nextLevelData = GetNextLevelData(currentLevelData.LevelId);
        return new EndGameSceneParameters(currentLevelData, nextLevelData);
    }

    private static LevelData GetNextLevelData(int currentLevelId)
    {
        return PersistentStateManager.GetLevelCompletionData(currentLevelId + 1);
    }
}

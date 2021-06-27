using UnityEngine;

public class GameManager : Manager
{
    private static int Score;
    public static bool GameOver;
    public string NextSceneToLoad;
    public override void onEvent(EventType eventType, GameObject source, int arg)
    {
        switch (eventType) {
            case EventType.AsteroidDestroyed:
                Score += 1000;
                break;
        }
    }

    public static void NotifyGameEnded()
    {
        if (!GameOver)
        {
            GameEndHelpers.TransitionToGameEndedScreen(PersistentStateManager.GetLevelCompletionData(CurrentLevelInfoHolder.CurrentLevelId));
        }
        GameOver = true;
    }
}

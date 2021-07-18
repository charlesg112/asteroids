using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndScreenActions : MonoBehaviour
{
    public void LoadNextLevel()
    {
        SceneManager.LoadSceneAsync(GameEndSceneLoader.EndGameSceneParameters.NextLevelData.SceneName);
    }
}

using System.Collections;
using Assets.Tests;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class GameEndScreenTests
{
    public IEnumerator WaitForNextSceneToLoad()
    {
        yield return new WaitForFixedUpdate();
        yield return new WaitForFixedUpdate();
    }

    [UnityTest]
    public IEnumerator GivenValidEndScreenParameters_WhenClickingOnNextLevelButton_ThenNextLevelSceneShouldBeOpened()
    {
        // Arrange
        LevelData nextSceneLevelData = Helpers.GetMockPersistentState().LevelDataList[0];
        GameEndSceneLoader.EndGameSceneParameters.NextLevelData = nextSceneLevelData;
        yield return SceneManager.LoadSceneAsync(GameInfo.SCENE_NAME_OF_DEFAULT_END_SCREEN);
        yield return new WaitForFixedUpdate();

        // Act
        GameObject nextLevelGameObject = GameObject.Find(GameInfo.GAMEOBJECT_NAME_OF_END_SCREEN_NEXT_LEVEL_BUTTON);
        Button nextLevelButton = nextLevelGameObject.GetComponent(typeof(Button)) as Button;
        nextLevelButton.onClick.Invoke();

        yield return WaitForNextSceneToLoad();

        // Assert
        Assert.AreEqual(nextSceneLevelData.SceneName, SceneManager.GetActiveScene().name);
    }
}

using System.Collections;
using System.IO;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class GameEndSceneLoaderTests
{
    [UnityTest]
    public IEnumerator GivenLevelDataWhichIsNotLast_WhenLoadingNextLevel_ShouldChangeSceneToDefaultEndGameScreen()
    {
        // Arrange
        PersistentState persistentState = PlayModeTestsHelpers.SetMockPersistentState();

        // Act
        yield return GameEndSceneLoader.LoadGameEndScreen(persistentState.LevelDataList[0]);

        // Assert
        Assert.AreEqual(GameInfo.SCENE_NAME_OF_DEFAULT_END_SCREEN, SceneManager.GetActiveScene().name);
    }

    [UnityTest]
    public IEnumerator GivenLevelDataWhichIsNotLast_WhenLoadingNextLevel_ShouldDisplayValidLevelName()
    {
        // Arrange
        PersistentState persistentState = PlayModeTestsHelpers.SetMockPersistentState();
        LevelData currentLevel = persistentState.LevelDataList[0];

        // Act
        yield return GameEndSceneLoader.LoadGameEndScreen(currentLevel);
        yield return new WaitForFixedUpdate();

        // Assert
        GameObject levelTitleDisplay = GameObject.Find(GameInfo.GAMEOBJECT_NAME_OF_END_SCREEN_LEVEL_TITLE);
        Assert.IsNotNull(levelTitleDisplay);

        TextMeshProUGUI textComponent = levelTitleDisplay.GetComponent(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
        Assert.AreEqual(currentLevel.LevelName, textComponent.text);
    }

    [UnityTest]
    public IEnumerator GivenLevelDataWhichIsNotLast_WhenLoadingNextLevel_ShouldDisplayValidNextLevelButton()
    {
        // Arrange
        PersistentState persistentState = PlayModeTestsHelpers.SetMockPersistentState();
        LevelData currentLevel = persistentState.LevelDataList[0];
        LevelData nextLevel = persistentState.LevelDataList[1];

        // Act
        yield return GameEndSceneLoader.LoadGameEndScreen(currentLevel);
        yield return new WaitForFixedUpdate();

        // Assert
        GameObject nextLevelButtonGameObject = GameObject.Find(GameInfo.GAMEOBJECT_NAME_OF_END_SCREEN_NEXT_LEVEL_BUTTON);
        Assert.IsNotNull(nextLevelButtonGameObject);

        TextMeshProUGUI textComponent = nextLevelButtonGameObject.GetComponentInChildren(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
        Assert.AreEqual(nextLevel.LevelName, textComponent.text);
    }
}

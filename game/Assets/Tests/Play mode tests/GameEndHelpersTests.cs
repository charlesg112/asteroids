using System.Collections;
using System.IO;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class GameEndHelpersTests
{
    public PersistentState SetMockPersistentState()
    {
        PersistentState persistentState = Assets.Tests.Helpers.GetMockPersistentState();
        PersistentStateManager.SetSavePath($"{Directory.GetCurrentDirectory()}/tests.txt");
        PersistentStateManager.SetPersistentState(persistentState);
        return persistentState;
    }

    [UnityTest]
    public IEnumerator GivenLevelDataWhichIsNotLast_WhenLoadingNextLevel_ShouldChangeSceneToDefaultEndGameScreen()
    {
        // Arrange
        PersistentState persistentState = SetMockPersistentState();

        // Act
        yield return GameEndSceneLoader.LoadGameEndScreen(persistentState.LevelDataList[0]);

        // Assert
        Assert.AreEqual(GameInfo.SCENE_NAME_OF_DEFAULT_END_SCREEN, SceneManager.GetActiveScene().name);
    }

    [UnityTest]
    public IEnumerator GivenLevelDataWhichIsNotLast_WhenLoadingNextLevel_ShouldDisplayValidLevelName()
    {
        // Arrange
        PersistentState persistentState = SetMockPersistentState();
        LevelData currentLevel = persistentState.LevelDataList[0];

        // Act
        yield return GameEndSceneLoader.LoadGameEndScreen(currentLevel);

        // Assert
        GameObject levelTitleDisplay = GameObject.Find(GameInfo.GAMEOBJECT_NAME_OF_END_SCREEN_LEVEL_TITLE);
        Assert.IsNotNull(levelTitleDisplay);

        TextMeshProUGUI textComponent = levelTitleDisplay.GetComponent(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
        Assert.AreEqual(currentLevel.LevelName, textComponent.text);
    }
}

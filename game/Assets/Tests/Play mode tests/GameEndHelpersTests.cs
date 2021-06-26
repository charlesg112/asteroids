using System.Collections;
using System.IO;
using NUnit.Framework;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class GameEndHelpersTests
{
    [UnityTest]
    public IEnumerator GivenLevelDataWhichIsNotLast_WhenLoadingNextLevel_ShouldChangeSceneToDesiredLevel()
    {
        PersistentState persistentState = Assets.Tests.Helpers.GetMockPersistentState();
        PersistentStateManager.SetSavePath($"{Directory.GetCurrentDirectory()}/tests.txt");
        PersistentStateManager.SetPersistentState(persistentState);

        // Act
        yield return GameEndSceneLoader.LoadGameEndScreen(persistentState.LevelDataList[0]);

        // Assert
        Assert.AreEqual(persistentState.LevelDataList[1].SceneName, SceneManager.GetActiveScene().name);
    }
}

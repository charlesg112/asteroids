using System;
using System.Collections;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class MenuScreenTests
{
    [UnityTest]
    public IEnumerator GivenValidPersistentState_WhenLoadingMenuScreen_ShouldApplyLevelDataToMenuLevelButtonsWithMatchingIDs()
    {
        PersistentState persistentState = PlayModeTestsHelpers.SetMockPersistentState();
        LevelData expectedLevelData = persistentState.LevelDataList[0];
        LevelData actualLevelData = null;
        yield return SceneManager.LoadSceneAsync(GameInfo.SCENE_NAME_OF_MENU_SCREEN);
        yield return new WaitForFixedUpdate();

        // Act
        GameObject[] levelButtonGameObjects = GameObject.FindGameObjectsWithTag(GameInfo.TAG_OF_MENU_LEVEL_BUTTON);
        foreach (GameObject gameObject in levelButtonGameObjects)
        {
            MenuLevelButton menuLevelButton = gameObject.GetComponent(typeof(MenuLevelButton)) as MenuLevelButton;
            if (menuLevelButton.LevelId == expectedLevelData.LevelId)
            {
                actualLevelData = menuLevelButton.LevelData;
            }
        }

        // Assert
        Assert.AreEqual(expectedLevelData, actualLevelData);
    }

    [UnityTest]
    public IEnumerator GivenValidPersistentState_WhenLoadingMenuScreen_ShouldDisplayValidLevelName()
    {
        PersistentState persistentState = PlayModeTestsHelpers.SetMockPersistentState();
        int targetedLevelID = persistentState.LevelDataList[0].LevelId;
        string expectedLevelTitle = persistentState.LevelDataList[targetedLevelID].LevelName;
        string actualLevelTitle = null;
        yield return SceneManager.LoadSceneAsync(GameInfo.SCENE_NAME_OF_MENU_SCREEN);
        yield return new WaitForFixedUpdate();

        // Act
        GameObject[] levelButtonGameObjects = GameObject.FindGameObjectsWithTag(GameInfo.TAG_OF_MENU_LEVEL_BUTTON);
        foreach (GameObject gameObject in levelButtonGameObjects)
        {
            MenuLevelButton menuLevelButton = gameObject.GetComponent(typeof(MenuLevelButton)) as MenuLevelButton;
            if (menuLevelButton.LevelId == targetedLevelID)
            {
                GameObject levelTitleGameObject = gameObject.transform.Find(GameInfo.GAMEOBJECT_NAME_OF_MENU_SCREEN_LEVEL_BUTTON_NAME).gameObject;
                TextMeshProUGUI tmp = levelTitleGameObject.GetComponent(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
                actualLevelTitle = tmp.text;
            }
        }

        // Assert
        Assert.AreEqual(expectedLevelTitle, actualLevelTitle);
    }

    [UnityTest]
    public IEnumerator GivenValidPersistentState_WhenLoadingMenuScreen_ShouldDisplayValidLevelScore()
    {
        PersistentState persistentState = PlayModeTestsHelpers.SetMockPersistentState();
        int targetedLevelID = persistentState.LevelDataList[0].LevelId;
        int expectedLevelScore = persistentState.LevelDataList[targetedLevelID].Score;
        int actualLevelScore = -1;
        yield return SceneManager.LoadSceneAsync(GameInfo.SCENE_NAME_OF_MENU_SCREEN);
        yield return new WaitForFixedUpdate();

        // Act
        GameObject[] levelButtonGameObjects = GameObject.FindGameObjectsWithTag(GameInfo.TAG_OF_MENU_LEVEL_BUTTON);
        foreach (GameObject gameObject in levelButtonGameObjects)
        {
            MenuLevelButton menuLevelButton = gameObject.GetComponent(typeof(MenuLevelButton)) as MenuLevelButton;
            if (menuLevelButton.LevelId == targetedLevelID)
            {
                GameObject levelTitleGameObject = gameObject.transform.Find(GameInfo.GAMEOBJECT_NAME_OF_MENU_SCREEN_LEVEL_BUTTON_SCORE).gameObject;
                TextMeshProUGUI tmp = levelTitleGameObject.GetComponent(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
                actualLevelScore = int.Parse(tmp.text);
            }
        } 

        // Assert
        Assert.AreEqual(expectedLevelScore, actualLevelScore);
    }
}

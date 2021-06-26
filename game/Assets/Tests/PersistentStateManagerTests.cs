using System.Collections;
using System.Collections.Generic;
using System.IO;
using Assets.Tests;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PersistentStateManagerTests
{

    [SetUp]
    public void BeforeEachTest()
    {
        PersistentStateManager.SetSavePath(Directory.GetCurrentDirectory() + "/testsave.txt");
    }

    [Test]
    public void GivenValidPersistentState_WhenSavingAndRetrievingPersistentState_ThenShouldPreserveSameLevelDataList()
    {
        // Arrange
        List<LevelData> levelDataList = Helpers.GetMockPersistentState().LevelDataList;
        
        // Act
        PersistentStateManager.SetPersistentState(new PersistentState(levelDataList));
        PersistentStateManager.SaveState();
        PersistentStateManager.RetrieveState();

        // Assert
        Assert.AreEqual(levelDataList, PersistentStateManager.GetPersistentState().LevelDataList);
    }

    [Test]
    public void GivenValidLevelCompletionData_WhenSavingLevelCompletionData_ThenShouldChangeTheLevelCompletionDataWithDesiredID()
    {
        // Arrange
        List<LevelData> levelDataList = Helpers.GetMockPersistentState().LevelDataList;
        int levelId = levelDataList[0].LevelId;
        int newScore = 812378;

        // Act
        PersistentStateManager.SetPersistentState(new PersistentState(levelDataList));
        PersistentStateManager.SaveLevelCompletionData(levelId, newScore);

        // Assert
        Assert.AreEqual(newScore, PersistentStateManager.GetPersistentState().LevelDataList[0].Score);
    }

    [Test]
    public void GivenInvalidLevelCompletionData_WhenSavingLevelCompletionData_ThenShouldThrowLevelNotRegisteredException()
    {
        // Arrange
        List<LevelData> levelDataList = Helpers.GetMockPersistentState().LevelDataList;
        int levelId = 231023;
        int newScore = 812378;

        // Act
        PersistentStateManager.SetPersistentState(new PersistentState(levelDataList));


        // Assert
        var ex = Assert.Throws<LevelNotRegisteredException>(() => PersistentStateManager.SaveLevelCompletionData(levelId, newScore));
        Assert.IsInstanceOf(typeof(LevelNotRegisteredException), ex);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator PersistentStateManagerTestsWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}

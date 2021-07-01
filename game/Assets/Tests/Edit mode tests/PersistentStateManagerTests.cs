using System.Collections.Generic;
using System.IO;
using Assets.Tests;
using NUnit.Framework;

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
    public void GivenValidPersistentState_WhenSavingAndRetrievingPersistentState_ThenShouldPreserveSameKeyBinds()
    {
        // Arrange
        List<KeyBind> expectedKeyBinds = Helpers.GetMockPersistentState().KeyBinds;

        // Act
        PersistentStateManager.SetPersistentState(Helpers.GetMockPersistentState());
        PersistentStateManager.SaveState();
        PersistentStateManager.RetrieveState();

        // Assert
        Assert.AreEqual(expectedKeyBinds, PersistentStateManager.GetPersistentState().KeyBinds);
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

    [Test]
    public void GivenValidLevelId_WhenGettingLevelData_ThenShouldGetDesiredLevelData()
    {
        // Arrange
        List<LevelData> levelDataList = Helpers.GetMockPersistentState().LevelDataList;
        PersistentStateManager.SetPersistentState(new PersistentState(levelDataList));
        LevelData desiredLevelData = levelDataList[0];
        
        // Act
        LevelData actualLevelData = PersistentStateManager.GetLevelCompletionData(desiredLevelData.LevelId);

        // Assert
        Assert.AreEqual(desiredLevelData, actualLevelData);
    }

    [Test]
    public void GivenInvalidLevelId_WhenGettingLevelData_ThenShouldThrowLevelNotRegisteredException()
    {
        // Arrange
        List<LevelData> levelDataList = Helpers.GetMockPersistentState().LevelDataList;
        PersistentStateManager.SetPersistentState(new PersistentState(levelDataList));
        int invalidLevelId = 1203123;

        // Assert
        var ex = Assert.Throws<LevelNotRegisteredException>(() => PersistentStateManager.GetLevelCompletionData(invalidLevelId));
        Assert.IsInstanceOf(typeof(LevelNotRegisteredException), ex);
    }

    [Test]
    public void GivenNonInitializedPersistentStateManager_WhenGettingLevelData_ThenShouldRetrieveStateFromDrive()
    {
        // Arrange
        List<LevelData> levelDataList = Helpers.GetMockPersistentState().LevelDataList;
        PersistentStateManager.SetPersistentState(new PersistentState(levelDataList));
        PersistentStateManager.SaveState();
        PersistentStateManager.SetPersistentState(null);
        LevelData exceptedLevelData = levelDataList[0];

        // Act
        LevelData actualLevelData = PersistentStateManager.GetLevelCompletionData(exceptedLevelData.LevelId);

        // Assert
        Assert.AreEqual(exceptedLevelData, actualLevelData);
    }

    [Test]
    public void GivenNonInitializedPersistentStateManager_WhenGettingPersistentState_ThenShouldRetrieveStateFromDrive()
    {
        // Arrange
        PersistentState expectedPersistentState = Helpers.GetMockPersistentState();
        PersistentStateManager.SetSavePath(Directory.GetCurrentDirectory() + "/testsaveuwu.txt");
        PersistentStateManager.SetPersistentState(expectedPersistentState);
        PersistentStateManager.SaveState();
        PersistentStateManager.SetPersistentState(null);

        // Act
        PersistentState actualPersistentState = PersistentStateManager.GetPersistentState();

        // Assert
        Assert.AreEqual(expectedPersistentState, actualPersistentState);
    }

    [Test]
    public void GivenValidPersistentState_WhenRestoringDefaultPersistentState_ThenDefaultPersistentStateShouldBeRestored()
    {
        // Arrange
        PersistentState expectedPersistentState = new PersistentState();
        PersistentStateManager.SetPersistentState(Helpers.GetMockPersistentState());
        PersistentStateManager.SaveState();

        // Act
        PersistentStateManager.RestoreDefaultPeristentState();

        // Assert
        Assert.AreEqual(expectedPersistentState, PersistentStateManager.GetPersistentState());
    }

    [Test]
    public void GivenInitializedPersistentStateManager_WhenChaningSavePath_ThenShouldSetInitializedPropertyToFalse()
    {
        // Arrange
        PersistentState expectedPersistentState = Helpers.GetMockPersistentState();
        PersistentStateManager.SetPersistentState(expectedPersistentState);
        PersistentStateManager.SaveState();

        // Act
        PersistentStateManager.SetSavePath("/testsss.txt");

        // Assert
        Assert.IsFalse(PersistentStateManager.Initialized);
    }

    [Test]
    public void GivenNonInitializedPersistentStateManager_WhenRetrievingDataForTheFirstTime_ThenShouldSetInitializedPropertyToTrue()
    {
        // Act
        PersistentStateManager.RetrieveState();

        // Assert
        Assert.IsTrue(PersistentStateManager.Initialized);
    }

    [Test]
    public void GivenNonInitializedPersistentStateManager_WhenSettingPersistentState_ThenShouldSetInitializedPropertyToTrue()
    {
        // Act
        PersistentStateManager.SetPersistentState(Helpers.GetMockPersistentState());

        // Assert
        Assert.IsTrue(PersistentStateManager.Initialized);
    }
}

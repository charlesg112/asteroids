using System.IO;
using Assets.Tests;
using NUnit.Framework;

public class PersistentStateRepositoryInJSONTest
{

    private string SavePath = Directory.GetCurrentDirectory() + "/testsave.txt";
    PersistentState ValidPersistentState = Helpers.GetMockPersistentState();
    PersistentStateRepositoryInJSON persistentStateRepositoryInJSON;

    [SetUp]
    public void BeforeEachTest()
    {
        persistentStateRepositoryInJSON = new PersistentStateRepositoryInJSON(SavePath);
    }

    [Test]
    public void GivenRepositoryContainingData_WhenRetrieving_ShouldRetrieveSameData()
    {
        persistentStateRepositoryInJSON.SavePeristentState(ValidPersistentState);

        PersistentState retrievedPersistentState = persistentStateRepositoryInJSON.RetrievePersistentState();

        Assert.AreEqual(retrievedPersistentState.LevelDataList, ValidPersistentState.LevelDataList);
        Assert.AreEqual(retrievedPersistentState.KeyBinds, ValidPersistentState.KeyBinds);
    }

   
}

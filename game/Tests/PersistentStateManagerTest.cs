using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class PersistentStateManagerTest
    {
        [TestMethod]
        public void WhenSaving_ThenLoading_ShouldReturnValidLevelDataList()
        {
            // Arrange
            List<LevelData> levelDataList = new List<LevelData>();
            LevelData levelDataFirstValue = new LevelData(0, "cool name", true, false, 100, 5);
            LevelData levelDataSecondValue = new LevelData(1, "poggers", false, false, 0, 0);
            levelDataList.Add(levelDataFirstValue);
            levelDataList.Add(levelDataSecondValue);

            // Act
            PersistentState desiredState = new PersistentState();
            desiredState.LevelDataList = levelDataList;
            PersistentStateManager.SetSavePath("testfile");
            PersistentStateManager.SaveState();
            PersistentStateManager.RetrieveState();

            // Assert
            Assert.AreEqual(desiredState, PersistentStateManager.PersistentState);

        }
    }
}

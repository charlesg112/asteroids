using System.Collections.Generic;

namespace Assets.Tests
{
    static class Helpers
    {
        static public PersistentState GetMockPersistentState()
        {
            // LevelData
            LevelData levelData1 = new LevelData(0, "level 1", true, false, 100, 5, "scene_level_1");
            LevelData levelData2 = new LevelData(1, "level 2", false, false, 200, 5, "scene_level_2");
            List<LevelData> levelDataList = new List<LevelData>();
            levelDataList.Add(levelData1);
            levelDataList.Add(levelData2);


            // PeristentState
            PersistentState output = new PersistentState();
            output.LevelDataList = levelDataList;

            return output;
        }
    }
}

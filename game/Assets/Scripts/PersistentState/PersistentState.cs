using System;
using System.Collections.Generic;

[Serializable]
public class PersistentState
{
    public List<LevelData> LevelDataList;
    public PersistentState()
    {
        LevelDataList = new List<LevelData>();
    }
    public PersistentState(List<LevelData> levelDataList)
    {
        LevelDataList = levelDataList;
    }
}

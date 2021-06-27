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

    public override bool Equals(object obj)
    {
        PersistentState other = obj as PersistentState;
        if (other == null)
        {
            return false;
        }
        return other.GetHashCode() == GetHashCode();
    }

    public override int GetHashCode()
    {
        return 235806273 + EqualityComparer<List<LevelData>>.Default.GetHashCode(LevelDataList);
    }
}

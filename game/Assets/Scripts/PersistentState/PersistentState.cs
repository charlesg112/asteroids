using System;
using System.Collections.Generic;

[Serializable]
public class PersistentState
{
    public List<LevelData> LevelDataList;
    public List<KeyBind> KeyBinds;
    public PersistentState()
    {
        LevelDataList = new List<LevelData>();
        KeyBinds = new List<KeyBind>();
    }
    public PersistentState(List<LevelData> levelDataList)
    {
        LevelDataList = levelDataList;
        KeyBinds = new List<KeyBind>();
    }

    public PersistentState(List<LevelData> levelDataList, List<KeyBind> keyBinds)
    {
        LevelDataList = levelDataList;
        KeyBinds = keyBinds;
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
        int output = 235806273;
        foreach(LevelData levelData in LevelDataList)
        {
            output = 31 * output + levelData.GetHashCode();
        }
        foreach(KeyBind keyBind in KeyBinds)
        {
            output = 31 * output + keyBind.GetHashCode();
        }
        return output;
    }
}

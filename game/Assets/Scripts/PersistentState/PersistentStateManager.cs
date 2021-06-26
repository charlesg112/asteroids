using System;
using System.IO;
using UnityEngine;

public static class PersistentStateManager
{
    private static string SavePath = Directory.GetCurrentDirectory() + "/testsave.txt";
    private static bool Initialized = false;
    private static PersistentState PersistentState;

    public static PersistentState GetPersistentState()
    {
        return PersistentState;
    }
    public static void SetPersistentState(PersistentState persistentState)
    {
        PersistentState = persistentState;
    }

    private static void RetrieveStateIfNotYetRetrieved()
    {
        if (!Initialized) RetrieveState();
        Initialized = true;
    }

    public static void SaveState()
    {
        string save = JsonUtility.ToJson(PersistentState);
        File.WriteAllText(SavePath, save);
    }
    public static void RetrieveState()
    {
        string save = File.ReadAllText(SavePath);
        PersistentState = JsonUtility.FromJson<PersistentState>(save);
    }

    public static void SaveLevelCompletionData(int levelId, int score)
    {
        RetrieveStateIfNotYetRetrieved();
        try
        {
            PersistentState.LevelDataList[levelId].Completed = true;
            PersistentState.LevelDataList[levelId].Score = score;
        }
        catch
        {
            throw new LevelNotRegisteredException($"{levelId}");
        }
    }
    public static void SaveLevelCompletionData(LevelData levelData)
    {
        RetrieveStateIfNotYetRetrieved();
        try
        {
            PersistentState.LevelDataList[levelData.LevelId] = levelData;
        }
        catch
        {
            throw new LevelNotRegisteredException($"{levelData.LevelId}");
        }
    }
    public static LevelData GetLevelCompletionData(int levelId)
    {
        try
        {
            return PersistentState.LevelDataList[levelId];
        }
        catch
        {
            throw new LevelNotRegisteredException($"{levelId}");
        }
    }
    public static void RestoreDefaultPeristentState()
    {
        PersistentState = new PersistentState();
        SaveState();
    }

    public static void SetSavePath(string savePath)
    {
        SavePath = savePath;
    }
}

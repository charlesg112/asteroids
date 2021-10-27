using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class PersistentStateManager
{
    #region Attributes
    private static string SavePath = Directory.GetCurrentDirectory() + "/testsave.txt";
    private static PersistentState PersistentState;
    private static PersistentStateRepository PersistentStateRepository = new PersistentStateRepositoryInJSON(SavePath);
    public static bool Initialized { get; private set; } = false;
    #endregion

    public static PersistentState GetPersistentState()
    {
        RetrieveStateIfNotYetRetrieved();
        return PersistentState;
    }
    public static void SetPersistentState(PersistentState persistentState)
    {
        PersistentState = persistentState;
        Initialized = true;
    }

    private static void RetrieveStateIfNotYetRetrieved()
    {
        if (!Initialized || PersistentState == null) RetrieveState();
        Initialized = true;
    }

    public static void SaveState()
    {
        PersistentStateRepository.SavePeristentState(PersistentState);
    }
    public static void RetrieveState()
    {
        PersistentState = PersistentStateRepository.RetrievePersistentState();
        Initialized = true;
    }

    public static void SaveLevelCompletionData(int levelId, int score)
    {
        try
        {
            GetPersistentState().LevelDataList[levelId].Completed = true;
            GetPersistentState().LevelDataList[levelId].Score = score;
        }
        catch
        {
            throw new LevelNotRegisteredException($"{levelId}");
        }
    }
    public static void SaveLevelCompletionData(LevelData levelData)
    {
        try
        {
            GetPersistentState().LevelDataList[levelData.LevelId] = levelData;
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
            return GetPersistentState().LevelDataList[levelId];
        }
        catch
        {
            throw new LevelNotRegisteredException($"{levelId}");
        }
    }

    internal static void SaveKeyBinds(List<KeyBind> keyBinds)
    {
        PersistentState.KeyBinds = keyBinds;
        SaveState();
    }

    public static void RestoreDefaultPeristentState()
    {
        PersistentState = new PersistentState();
    }

    public static void SetSavePath(string savePath)
    {
        SavePath = savePath;
        Initialized = false;
    }
}

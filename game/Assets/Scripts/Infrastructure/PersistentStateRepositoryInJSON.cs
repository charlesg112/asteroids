using System.IO;
using UnityEngine;

public class PersistentStateRepositoryInJSON : PersistentStateRepository
{

    private string SavePath;
    public PersistentStateRepositoryInJSON(string savePath)
    {
        SavePath = savePath;
    }

    public PersistentState RetrievePersistentState()
    {
        string save = File.ReadAllText(SavePath);
        return JsonUtility.FromJson<PersistentState>(save);
    }

    public void SavePeristentState(PersistentState state)
    {
        string save = JsonUtility.ToJson(state);
        Debug.Log(Directory.GetCurrentDirectory());
        File.WriteAllText(SavePath, save);
    }

}

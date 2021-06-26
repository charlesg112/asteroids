using System;
using System.Collections.Generic;

[Serializable]
public class LevelData
{
    public int LevelId;
    public string LevelName;
    public bool Completed;
    public bool Locked;
    public int Score;
    public int Stars;
    public string SceneName;

    public LevelData(int levelId, string levelName, bool completed, bool locked, int score, int stars, string sceneName)
    {
        LevelId = levelId;
        LevelName = levelName;
        Completed = completed;
        Locked = locked;
        Score = score;
        Stars = stars;
        SceneName = sceneName;
    }

    public override bool Equals(object obj)
    {
        LevelData other = obj as LevelData;
        if (other == null)
        {
            return false;
        }
        return other.GetHashCode() == GetHashCode();
    }

    public override int GetHashCode()
    {
        int hashCode = 150998862;
        hashCode = hashCode * -1521134295 + LevelId.GetHashCode();
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LevelName);
        hashCode = hashCode * -1521134295 + Completed.GetHashCode();
        hashCode = hashCode * -1521134295 + Locked.GetHashCode();
        hashCode = hashCode * -1521134295 + Score.GetHashCode();
        hashCode = hashCode * -1521134295 + Stars.GetHashCode();
        hashCode = hashCode * -1521134295 + SceneName.GetHashCode();
        return hashCode;
    }
}

using UnityEngine;

public class CurrentLevelInfoHolder : MonoBehaviour
{
    public static int CurrentLevelId;
    public int SetLevelIdValueTo;
    public void Start()
    {
        CurrentLevelId = SetLevelIdValueTo;
    }
}

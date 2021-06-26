using UnityEngine;
public class UIReducer
{
    public void Reduce(UIEventType eventType)
    {
        Debug.Log($"New UI event to reduce : {eventType}");
    }
}

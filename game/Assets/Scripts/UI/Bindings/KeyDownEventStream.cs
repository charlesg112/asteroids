using UnityEngine;

public class KeyDownEventStream : MonoBehaviour
{
    private void OnGUI()
    {
        Event e = Event.current;
        if (e.isKey)
        {
            UIEventBus.Publish(UIEventType.KeyDown, e.keyCode);
        }   
    }
}

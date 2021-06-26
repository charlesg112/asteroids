using System.Collections.Generic;

public class UIEventBus
{
    private static List<UIEventListener> eventListeners = new List<UIEventListener>();
    public static void Subscribe(UIEventListener listener)
    {
        eventListeners.Add(listener);
    }
    public static void Publish(UIEventType type, UIComponent source)
    {
        foreach (UIEventListener listener in eventListeners)
        {
            listener.onUIEvent(type, source);
        }
    }
}

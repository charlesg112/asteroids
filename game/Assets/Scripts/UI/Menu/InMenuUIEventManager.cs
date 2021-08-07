using UnityEngine;

public class InMenuUIEventManager : NonselectiveUIEventManager<MenuState>
{
    public override void onUIEvent(UIEventType eventType, Component source)
    {
        throw new System.NotImplementedException();
    }
    public override void onUIEvent(UIEventType eventType, KeyCode keyCode)
    {
        throw new System.NotImplementedException();
    }

    protected override MenuState FetchCurrentState()
    {
        MenuState output = new MenuState();
        output.PersistentState = PersistentStateManager.GetPersistentState();
        return output;
    }
}

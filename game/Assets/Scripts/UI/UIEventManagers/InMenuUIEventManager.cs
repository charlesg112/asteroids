using UnityEngine;

public class InMenuUIEventManager : UIEventManager<GameState>
{
    public override void onUIEvent(UIEventType eventType, Component source)
    {
        throw new System.NotImplementedException();
    }
    public override void onUIEvent(UIEventType eventType, KeyCode keyCode)
    {
        throw new System.NotImplementedException();
    }

    protected override GameState FetchCurrentState()
    {
        GameState output = new GameState();
        output.PersistentState = PersistentStateManager.GetPersistentState();
        return output;
    }
}

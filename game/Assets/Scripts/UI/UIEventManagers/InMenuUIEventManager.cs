using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InMenuUIEventManager : UIEventManager
{
    public override void onUIEvent(UIEventType eventType, UIComponent source)
    {
        throw new System.NotImplementedException();
    }

    protected override GameState FetchGameState()
    {
        GameState output = new GameState();
        output.PersistentState = PersistentStateManager.GetPersistentState();
        return output;
    }
}

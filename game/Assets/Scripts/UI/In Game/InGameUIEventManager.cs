using System.Collections.Generic;
using UnityEngine;

public class InGameUIEventManager : SelectiveUIEventManager<GameState>
{
    protected override GameState FetchCurrentState() 
    {
        GameState gameState = new GameState();
        gameState.MaximumNumberOfBulletsInstances = GameInfo.GetMaximumBulletsInstantiated();
        gameState.CurrentInventory = InventorySupervisor.GetInstance().GetCurrentInventory();
        return gameState;
    }

    public override void onUIEvent(UIEventType eventType, Component source) { }
    public override void onUIEvent(UIEventType eventType, KeyCode keyCode) { }

    protected override List<EventType> GetForceRefreshEvents()
    {
        return new List<EventType> { EventType.PickableItemPickedUp };
    }

    protected override List<EventType> GetIgnoreEvents()
    {
        return new List<EventType>();
    }
}

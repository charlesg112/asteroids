using UnityEngine;

public class InGameUIEventManager : UIEventManager<GameState>
{
    protected override GameState FetchCurrentState() 
    {
        GameState gameState = new GameState();
        gameState.MaximumNumberOfBulletsInstances = GameInfo.GetMaximumBulletsInstantiated();
        gameState.CurrentInventory = InventorySupervisor.GetCurrentInventory();
        Debug.Log(gameState.CurrentInventory);
        return gameState;
    }

    public override void onUIEvent(UIEventType eventType, Component source) { }
    public override void onUIEvent(UIEventType eventType, KeyCode keyCode) { }
}

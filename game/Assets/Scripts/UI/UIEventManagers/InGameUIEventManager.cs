public class InGameUIEventManager : UIEventManager
{
    protected override GameState FetchGameState() 
    {
        GameState gameState = new GameState();
        gameState.MaximumNumberOfBulletsInstances = GameInfo.GetMaximumBulletsInstantiated();
        return gameState;
    }

    public override void onUIEvent(UIEventType eventType, UIComponent source) { }
}

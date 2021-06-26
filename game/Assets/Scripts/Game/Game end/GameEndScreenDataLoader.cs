using TMPro;

public class GameEndScreenDataLoader : UIComponent
{
    public TextMeshProUGUI LevelName;

    public override bool IsUpdateRequired(GameState gameState)
    {
        return false;
    }

    public override void Render(GameState gameState)
    {
        throw new System.NotImplementedException();
    }
}

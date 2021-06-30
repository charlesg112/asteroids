using TMPro;

public class MenuLevelButton : UIComponent
{
    public int LevelId;
    public TextMeshProUGUI ScorePlaceholder;
    public TextMeshProUGUI NamePlaceholder;
    public LevelData LevelData { get; private set; }

    public override bool IsUpdateRequired(GameState gameState)
    {
        return gameState.PersistentState.LevelDataList[LevelId] != LevelData;
    }

    public override void Render(GameState gameState)
    {
        LevelData = gameState.PersistentState.LevelDataList[LevelId];
        NamePlaceholder.text = LevelData.LevelName;
    }
}
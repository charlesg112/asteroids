using TMPro;

public class MenuLevelButton : UIComponent<MenuState>
{
    public int LevelId;
    public TextMeshProUGUI ScorePlaceholder;
    public TextMeshProUGUI NamePlaceholder;
    public LevelData LevelData { get; private set; }

    public override bool IsUpdateRequired(MenuState gameState)
    {
        return gameState.PersistentState.LevelDataList[LevelId] != LevelData;
    }

    public override void Render(MenuState gameState)
    {
        LevelData = gameState.PersistentState.LevelDataList[LevelId];
        NamePlaceholder.text = LevelData.LevelName;
        ScorePlaceholder.text = LevelData.Score.ToString();
    }
}

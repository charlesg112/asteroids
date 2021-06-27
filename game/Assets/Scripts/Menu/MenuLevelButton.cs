using TMPro;
using UnityEngine;

public class MenuLevelButton : UIComponent
{
    public int LevelId;
    public LevelData LevelData;
    public TextMeshProUGUI ScorePlaceholder;
    public TextMeshProUGUI NamePlaceholder;

    public override bool IsUpdateRequired(GameState gameState)
    {
        throw new System.NotImplementedException();
    }

    public override void Render(GameState gameState)
    {
        throw new System.NotImplementedException();
    }
}

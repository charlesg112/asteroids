using TMPro;
using UnityEngine;

public class GameEndScreenDataLoader : UIComponent
{
    public TextMeshProUGUI LevelName;
    public TextMeshProUGUI NextLevelNameButton;
    private bool hasRenderedOnce = false;

    public override bool IsUpdateRequired(GameState gameState)
    {
        if (hasRenderedOnce) return false;
        else
        {
            hasRenderedOnce = true;
            return true;
        }
    }

    public override void Render(GameState gameState)
    {
        LevelName.text = GameEndSceneLoader.EndGameSceneParameters.CurrentLevelData.LevelName;
        NextLevelNameButton.text = GameEndSceneLoader.EndGameSceneParameters.NextLevelData.LevelName;
    }
}

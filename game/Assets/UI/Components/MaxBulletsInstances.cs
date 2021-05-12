using TMPro;
using UnityEngine;

public class MaxBulletsInstances : UIComponent
{
    public TextMeshProUGUI BulletsInstancePlaceholder;
    private int? currentNumberOfBulletInstances;
    public override void Render(GameStateDTO gameState)
    {
        currentNumberOfBulletInstances = gameState.MaximumNumberOfBulletsInstances;
        BulletsInstancePlaceholder.text = currentNumberOfBulletInstances.ToString();
        Debug.Log($"Rendered with value : {currentNumberOfBulletInstances}");
    }

    public override void RenderIfRequired(GameStateDTO gameState)
    {
        Debug.Log($"Old bullets instances value : {currentNumberOfBulletInstances}, new : {gameState.MaximumNumberOfBulletsInstances}");
        if (currentNumberOfBulletInstances == null || gameState.MaximumNumberOfBulletsInstances != currentNumberOfBulletInstances)
        {
            Render(gameState);
        }
    }

}

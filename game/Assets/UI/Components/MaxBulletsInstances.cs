using UnityEngine;
using UnityEngine.UI;

public class MaxBulletsInstances : UIComponent
{
    public Text BulletsInstancePlaceholder;
    private int? currentNumberOfBulletInstances;
    public override void Render(GameStateDTO gameState)
    {
        currentNumberOfBulletInstances = gameState.MaximumNumberOfBulletsInstances;
        BulletsInstancePlaceholder.text = currentNumberOfBulletInstances.ToString();
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

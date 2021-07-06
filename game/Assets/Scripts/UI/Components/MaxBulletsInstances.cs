using TMPro;

public class MaxBulletsInstances : UIComponent<GameState>
{
    public TextMeshProUGUI BulletsInstancePlaceholder;
    private int? currentNumberOfBulletInstances;
    public override void Render(GameState gameState)
    {
        currentNumberOfBulletInstances = gameState.MaximumNumberOfBulletsInstances;
        BulletsInstancePlaceholder.text = currentNumberOfBulletInstances.ToString();
    }

    public override bool IsUpdateRequired(GameState gameState)
    {
        return currentNumberOfBulletInstances == null || gameState.MaximumNumberOfBulletsInstances != currentNumberOfBulletInstances;
    }

}

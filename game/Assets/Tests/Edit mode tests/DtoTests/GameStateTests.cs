using NUnit.Framework;
using System.Collections.Generic;

public class GameStateTests
{

    [Test]
    public void GivenEqualGameStates_WhenComparingBothStates_ShouldReturnEqual()
    {
        // Arrange
        int bulletsInstances = 10;
        List<UsableItem> usableItems = new List<UsableItem>();
        usableItems.Add(new FragBombUsableItem());
        GameState gameState1 = new GameState();
        GameState gameState2 = new GameState();
        gameState1.MaximumNumberOfBulletsInstances = gameState2.MaximumNumberOfBulletsInstances = bulletsInstances;
        gameState1.CurrentInventory = gameState2.CurrentInventory = usableItems;

        // Assert
        Assert.AreEqual(gameState1, gameState2);
    }

    [Test]
    public void GivenGameStatesWithDifferentInventories_WhenComparingBothStates_ShouldReturnNotEqual()
    {
        // Arrange
        int bulletsInstances = 10;
        GameState gameState1 = new GameState();
        GameState gameState2 = new GameState();
        gameState1.MaximumNumberOfBulletsInstances = gameState2.MaximumNumberOfBulletsInstances = bulletsInstances;
        gameState1.CurrentInventory = new List<UsableItem>();
        gameState2.CurrentInventory = new List<UsableItem>();
        gameState2.CurrentInventory.Add(new FragBombUsableItem());

        // Assert
        Assert.AreNotEqual(gameState1, gameState2);
    }

    [Test]
    public void GivenGameStatesWithDifferentMaxBullets_WhenComparingBothStates_ShouldReturnNotEqual()
    {
        // Arrange
        GameState gameState1 = new GameState();
        GameState gameState2 = new GameState();
        gameState1.CurrentInventory = new List<UsableItem>();
        gameState2.CurrentInventory = new List<UsableItem>();
        gameState1.MaximumNumberOfBulletsInstances = 1;
        gameState2.MaximumNumberOfBulletsInstances = 2;

        // Assert
        Assert.AreNotEqual(gameState1, gameState2);
    }
}

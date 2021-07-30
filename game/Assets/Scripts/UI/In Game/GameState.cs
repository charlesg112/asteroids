using System.Collections.Generic;
using UnityEngine;

public class GameState
{
    public int MaximumNumberOfBulletsInstances;
    public List<UsableItem> CurrentInventory;
    
    public override bool Equals(object obj)
    {
        GameState other = (GameState)obj;
        if (other is null) return false;
        return this.GetHashCode() == other.GetHashCode();
    }

    public override int GetHashCode()
    {
        int hashCode = -875679996;
        hashCode = hashCode * -1521134295 + MaximumNumberOfBulletsInstances.GetHashCode();
        CurrentInventory.ForEach(usableItem => {
            hashCode = hashCode * -23 + usableItem.GetHashCode();
        });
        return hashCode;
    }
}

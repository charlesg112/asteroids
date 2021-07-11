public class GameState
{
    public int MaximumNumberOfBulletsInstances;
    public PersistentState PersistentState;
    
    public override bool Equals(object obj)
    {
        GameState other = (GameState)obj;
        if (other is null) return false;
        if (this.MaximumNumberOfBulletsInstances != other.MaximumNumberOfBulletsInstances) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return 948635478 + MaximumNumberOfBulletsInstances.GetHashCode();
    }
}
